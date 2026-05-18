#!/usr/bin/env python3
"""LeetCode CLI helper — fetch starter code and test cases."""

import html
import os
import re
import subprocess
import sys
from pathlib import Path
from urllib.parse import urlparse

import requests

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
    content
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

PROBLEM_BY_ID_QUERY = """
query questionByFrontendId($searchKeywords: String!) {
  problemsetQuestionList: questionList(
    categorySlug: ""
    limit: 10
    skip: 0
    filters: { searchKeywords: $searchKeywords }
  ) {
    questions: data {
      questionFrontendId
      titleSlug
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


def fetch_slug_by_id(problem_id: str, session: str) -> str:
    data = gql(PROBLEM_BY_ID_QUERY, {"searchKeywords": problem_id}, session)
    questions = (data.get("problemsetQuestionList") or {}).get("questions") or []
    for q in questions:
        if q["questionFrontendId"] == problem_id:
            return q["titleSlug"]
    sys.exit(f"Problem #{problem_id} not found.")


def get_csharp_snippet(question: dict) -> str:
    for s in question.get("codeSnippets") or []:
        if s["langSlug"] == "csharp":
            return s["code"]
    sys.exit(f"No C# snippet for: {question['titleSlug']}")


def open_in_editor(paths: list[Path]) -> None:
    editor = os.environ.get("LEETCODE_EDITOR", "none")
    if editor == "none":
        return
    str_paths = [str(p) for p in paths]
    try:
        if editor == "code":
            subprocess.run(["code", "-r"] + str_paths, check=True)
        else:
            subprocess.run([editor] + str_paths, check=True)
    except Exception as e:
        print(f"Could not open editor: {e}")


def parse_outputs(content: str) -> list[str]:
    if not content:
        return []
    text = re.sub(r'<br\s*/?>', '\n', content, flags=re.IGNORECASE)
    text = re.sub(r'</(p|pre|li)>', '\n', text, flags=re.IGNORECASE)
    text = re.sub(r'<[^>]+>', '', text)
    text = html.unescape(text)
    outputs = []
    for m in re.finditer(r'\bOutput:\s*([^\n]+)', text):
        val = m.group(1).strip()
        if val:
            outputs.append(val)
    return outputs


def guard_existing_files(paths: list[Path]) -> None:
    """Stop if any of the given paths exist and have content."""
    for p in paths:
        if p.exists() and p.stat().st_size > 0:
            sys.exit(
                f"File already has content: {p.relative_to(ROOT_DIR)}\nRemove or clear it first."
            )


# ── README helpers ────────────────────────────────────────────────────────────


def update_readme(readme_path, contest_type, contest_number):
    contest_label = contest_type.capitalize()
    section_header = f"### {contest_label} Contests"
    anchor = "<summary>Click to expand</summary>"
    new_entry = (
        f"\n\n- {contest_label} Contest {contest_number} (\n"
        + "".join(
            f"    [Q{i}](./contests/{contest_type}/{contest_number}/Q{i}.cs),\n"
            for i in range(1, 4)
        )
        + f"    [Q4](./contests/{contest_type}/{contest_number}/Q4.cs)\n  )"
    )

    with open(readme_path, "r", encoding="utf-8") as f:
        content = f.read()

    section_pos = content.find(section_header)
    if section_pos == -1:
        print(f"Could not find '{section_header}' in README.md")
        return

    anchor_pos = content.find(anchor, section_pos)
    if anchor_pos == -1:
        print("Could not find expand anchor in README.md")
        return

    search_start = anchor_pos + len(anchor)
    section_end_match = re.search(r"\n(###|</details>)", content[search_start:])
    section_end = (
        search_start + section_end_match.start() if section_end_match else len(content)
    )
    section_body = content[search_start:section_end]

    if f"- {contest_label} Contest {contest_number} (" in section_body:
        print(f"{contest_label} Contest {contest_number} already in README.md")
        return

    entry_pattern = re.compile(rf"- {re.escape(contest_label)} Contest (\d+) \(")
    insert_pos = search_start + len(section_body)
    for m in entry_pattern.finditer(section_body):
        if int(m.group(1)) < int(contest_number):
            insert_pos = search_start + m.start()
            while insert_pos > search_start and content[insert_pos - 1] == "\n":
                insert_pos -= 1
            break

    content = content[:insert_pos] + new_entry + content[insert_pos:]

    with open(readme_path, "w", encoding="utf-8") as f:
        f.write(content)

    print(f"Updated README.md with {contest_label} Contest {contest_number}")


def update_readme_problem(readme_path: str, problem_id: str, title: str) -> None:
    section_header = "## 💡 Problem Solutions"
    anchor = "<summary>Click to expand</summary>"
    new_entry = f"- [{problem_id}. {title}](./problems/{problem_id}/Solution.cs)\n"

    with open(readme_path, "r", encoding="utf-8") as f:
        content = f.read()

    section_pos = content.find(section_header)
    if section_pos == -1:
        print(f"Could not find '{section_header}' in README.md")
        return

    anchor_pos = content.find(anchor, section_pos)
    if anchor_pos == -1:
        print("Could not find expand anchor in README.md")
        return

    search_start = anchor_pos + len(anchor)
    section_end_match = re.search(r"\n(##|</details>)", content[search_start:])
    section_end = (
        search_start + section_end_match.start() if section_end_match else len(content)
    )
    section_body = content[search_start:section_end]

    if f"- [{problem_id}." in section_body:
        print(f"Problem #{problem_id} already in README.md")
        return

    entry_pattern = re.compile(r"- \[(\d+)\.")
    insert_pos = search_start + len(section_body)
    for m in entry_pattern.finditer(section_body):
        if int(m.group(1)) < int(problem_id):
            insert_pos = search_start + m.start()
            break

    content = content[:insert_pos] + new_entry + content[insert_pos:]

    with open(readme_path, "w", encoding="utf-8") as f:
        f.write(content)

    print(f"Updated README.md with problem #{problem_id}")


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
    outputs = parse_outputs(question.get("content", ""))

    solution_path.parent.mkdir(parents=True, exist_ok=True)
    solution_path.write_text(code + "\n")
    tc = ROOT_DIR / "testcases"
    tc.mkdir(exist_ok=True)
    (tc / "input.txt").write_text("\n".join(testcases) + "\n")
    (tc / "output.txt").write_text("\n".join(outputs) + "\n" if outputs else "")

    update_readme_problem(str(ROOT_DIR / "README.md"), problem_id, question["title"])

    open_in_editor(
        [
            ROOT_DIR / "README.md",
            ROOT_DIR / "testcases" / "output.txt",
            ROOT_DIR / "testcases" / "input.txt",
            solution_path,
        ]
    )

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
        outputs = parse_outputs(question.get("content", ""))

        cs_path = contest_dir / f"Q{i}.cs"
        cs_path.write_text(code + "\n")
        paths.append(cs_path)

        tc = ROOT_DIR / "testcases"
        tc.mkdir(exist_ok=True)
        (tc / f"input_{i}.txt").write_text("\n".join(testcases) + "\n")
        (tc / f"output_{i}.txt").write_text("\n".join(outputs) + "\n" if outputs else "")

        print(f"  Q{i}: #{question['questionFrontendId']} – {question['title']}")

    tc = ROOT_DIR / "testcases"
    (tc / "input.txt").write_text("")
    (tc / "output.txt").write_text("")

    update_readme(str(ROOT_DIR / "README.md"), contest_type, contest_number)

    open_in_editor(
        [
            ROOT_DIR / "README.md",
            ROOT_DIR / "testcases" / "output.txt",
            ROOT_DIR / "testcases" / "input.txt",
            *reversed(paths),
        ]
    )

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
        print("  lc <url>     — full LeetCode URL")
        print("  lc 113       — problem #113")
        print("  lc w113      — weekly contest 113")
        print("  lc b113      — biweekly contest 113")
        sys.exit(1)

    arg = sys.argv[1]
    if arg == "login":
        cmd_login(sys.argv[2] if len(sys.argv) > 2 else "")
    elif arg.startswith("http"):
        dispatch(arg)
    elif re.fullmatch(r"\d+", arg):
        session = get_session()
        slug = fetch_slug_by_id(arg, session)
        cmd_fetch_problem(slug)
    elif m := re.fullmatch(r"w(\d+)", arg):
        cmd_fetch_contest(f"weekly-contest-{m.group(1)}")
    elif m := re.fullmatch(r"b(\d+)", arg):
        cmd_fetch_contest(f"biweekly-contest-{m.group(1)}")
    else:
        sys.exit(
            f"Unknown argument: {arg!r}\n"
            "Usage:\n"
            "  lc login <cookie>\n"
            "  lc <url>     — full LeetCode URL\n"
            "  lc 113       — problem #113\n"
            "  lc w113      — weekly contest 113\n"
            "  lc b113     — biweekly contest 113"
        )


if __name__ == "__main__":
    main()
