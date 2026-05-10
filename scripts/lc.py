#!/usr/bin/env python3
"""LeetCode CLI helper — fetch starter code and test cases from a URL."""

import re
import sys
import requests
from pathlib import Path
from urllib.parse import urlparse

SCRIPT_DIR = Path(__file__).parent
ROOT_DIR = SCRIPT_DIR.parent
SESSION_FILE = SCRIPT_DIR / ".lc_session"
GRAPHQL_URL = "https://leetcode.com/graphql"

QUESTION_QUERY = """
query questionData($titleSlug: String!) {
  question(titleSlug: $titleSlug) {
    questionFrontendId
    title
    titleSlug
    codeSnippets { langSlug code }
    exampleTestcaseList
  }
}
"""

CONTEST_QUERY = """
query contestInfo($titleSlug: String!) {
  contest(titleSlug: $titleSlug) {
    title
    questions {
      titleSlug
      title
    }
  }
}
"""


# ── Helpers ───────────────────────────────────────────────────────────────────

def get_session() -> str:
    if not SESSION_FILE.exists():
        sys.exit("No session found. Run: lc login <LEETCODE_SESSION>")
    return SESSION_FILE.read_text().strip()


def gql(query: str, variables: dict, session: str) -> dict:
    resp = requests.post(
        GRAPHQL_URL,
        json={"query": query, "variables": variables},
        headers={
            "Cookie": f"LEETCODE_SESSION={session}",
            "Content-Type": "application/json",
            "Referer": "https://leetcode.com",
            "User-Agent": "Mozilla/5.0",
        },
        timeout=15,
    )
    resp.raise_for_status()
    data = resp.json()
    if "errors" in data:
        sys.exit(f"GraphQL error: {data['errors']}")
    return data["data"]


def fetch_question(slug: str, session: str) -> dict:
    data = gql(QUESTION_QUERY, {"titleSlug": slug}, session)
    q = data.get("question")
    if not q:
        sys.exit(f"Problem not found: {slug}")
    return q


def get_csharp_snippet(question: dict) -> str:
    for s in question.get("codeSnippets") or []:
        if s["langSlug"] == "csharp":
            return s["code"]
    sys.exit(f"No C# snippet for: {question['titleSlug']}")


def guard_existing_files(paths: list[Path]) -> None:
    """Stop if any of the given paths exist and have content."""
    for p in paths:
        if p.exists() and p.stat().st_size > 0:
            sys.exit(f"File already has content: {p.relative_to(ROOT_DIR)}\nRemove or clear it first.")


# ── Commands ──────────────────────────────────────────────────────────────────

def cmd_login(cookie: str) -> None:
    if not cookie:
        print("Usage: lc login <LEETCODE_SESSION>")
        print()
        print("To get your session cookie:")
        print("  1. Open leetcode.com in your browser while logged in")
        print("  2. DevTools → Application → Cookies → https://leetcode.com")
        print("  3. Copy the value of 'LEETCODE_SESSION'")
        print("  4. Run: lc login <paste-value-here>")
        sys.exit(1)
    # If the user pasted the full Cookie header string, extract just LEETCODE_SESSION
    if "LEETCODE_SESSION=" in cookie:
        m = re.search(r"LEETCODE_SESSION=([^;]+)", cookie)
        if m:
            cookie = m.group(1)
    SESSION_FILE.write_text(cookie.strip())
    print(f"Saved to {SESSION_FILE}")


def cmd_fetch_problem(slug: str) -> Path:
    session = get_session()
    question = fetch_question(slug, session)
    problem_id = question["questionFrontendId"]

    solution_path = ROOT_DIR / "problems" / problem_id / "Solution.cs"
    guard_existing_files([solution_path])

    code = get_csharp_snippet(question)
    testcases: list[str] = question.get("exampleTestcaseList") or []

    solution_path.parent.mkdir(parents=True, exist_ok=True)
    solution_path.write_text(code + "\n")
    tc = ROOT_DIR / "testcases"
    tc.mkdir(exist_ok=True)
    (tc / "input.txt").write_text("\n".join(testcases) + "\n")
    (tc / "output.txt").write_text("")

    sys.path.insert(0, str(SCRIPT_DIR))
    from genc import update_readme_problem
    update_readme_problem(str(ROOT_DIR / "README.md"), problem_id, question["title"])

    print(f"#{problem_id} – {question['title']}")
    print(f"  → {solution_path.relative_to(ROOT_DIR)}")
    print(f"  → testcases/input.txt  ({len(testcases)} test case(s))")
    return solution_path


def cmd_fetch_contest(contest_slug: str) -> list[Path]:
    m = re.match(r"(bi)?weekly-contest-(\d+)", contest_slug)
    if not m:
        sys.exit(f"Unrecognized contest slug: {contest_slug}")
    contest_type = "biweekly" if m.group(1) else "weekly"
    contest_number = m.group(2)

    contest_dir = ROOT_DIR / "contests" / contest_type / contest_number
    guard_existing_files([contest_dir / f"Q{i}.cs" for i in range(1, 5)])

    session = get_session()
    data = gql(CONTEST_QUERY, {"titleSlug": contest_slug}, session)
    contest_data = data.get("contest")
    if not contest_data or not contest_data.get("questions"):
        sys.exit("No problems found — contest may not have started yet.")

    questions_meta = contest_data["questions"]
    contest_dir.mkdir(parents=True, exist_ok=True)

    paths: list[Path] = []

    for i, meta in enumerate(questions_meta, start=1):
        question = fetch_question(meta["titleSlug"], session)
        code = get_csharp_snippet(question)
        testcases: list[str] = question.get("exampleTestcaseList") or []

        cs_path = contest_dir / f"Q{i}.cs"
        cs_path.write_text(code + "\n")
        paths.append(cs_path)

        tc = ROOT_DIR / "testcases"
        tc.mkdir(exist_ok=True)
        (tc / f"input_{i}.txt").write_text("\n".join(testcases) + "\n")
        (tc / f"output_{i}.txt").write_text("")

        print(f"  Q{i}: #{question['questionFrontendId']} – {question['title']}")

    tc = ROOT_DIR / "testcases"
    (tc / "input.txt").write_text("")
    (tc / "output.txt").write_text("")

    sys.path.insert(0, str(SCRIPT_DIR))
    from genc import update_readme
    update_readme(str(ROOT_DIR / "README.md"), contest_type, contest_number)

    print(f"\n→ {contest_dir.relative_to(ROOT_DIR)}/  ({len(paths)} problems)")
    print(f"→ testcases/input_1.txt … input_{len(paths)}.txt")
    return paths


# ── Dispatch ──────────────────────────────────────────────────────────────────

def dispatch(url: str) -> None:
    parsed = urlparse(url)
    parts = [p for p in parsed.path.split("/") if p]

    if parts and parts[0] == "problems":
        if len(parts) < 2:
            sys.exit("Missing problem slug in URL.")
        cmd_fetch_problem(parts[1])

    elif parts and parts[0] == "contest":
        if len(parts) < 2:
            sys.exit("Missing contest slug in URL.")
        contest_slug = parts[1]
        if len(parts) >= 4 and parts[2] == "problems":
            cmd_fetch_problem(parts[3])
        else:
            cmd_fetch_contest(contest_slug)

    else:
        sys.exit(
            f"Unrecognized URL: {url}\n"
            "Expected a leetcode.com /problems/ or /contest/ URL."
        )


# ── Entry point ───────────────────────────────────────────────────────────────

def main() -> None:
    if len(sys.argv) < 2:
        print("Usage:")
        print("  lc login <LEETCODE_SESSION>")
        print("  lc <leetcode-url>")
        sys.exit(1)

    arg = sys.argv[1]
    if arg == "login":
        cmd_login(sys.argv[2] if len(sys.argv) > 2 else "")
    elif arg.startswith("http"):
        dispatch(arg)
    else:
        sys.exit(f"Unknown argument: {arg!r}\nUse 'lc login <cookie>' or 'lc <url>'")


if __name__ == "__main__":
    main()
