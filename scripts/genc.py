import os
import re
import sys
import subprocess


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

    # Find the end of this section (next ### heading or </details>)
    search_start = anchor_pos + len(anchor)
    section_end_match = re.search(r"\n(###|</details>)", content[search_start:])
    section_end = search_start + section_end_match.start() if section_end_match else len(content)
    section_body = content[search_start:section_end]

    # Find insertion point: before the first entry with a smaller contest number
    entry_pattern = re.compile(
        rf"- {re.escape(contest_label)} Contest (\d+) \("
    )
    insert_pos = search_start + len(section_body)  # default: append at end of section
    for m in entry_pattern.finditer(section_body):
        if int(m.group(1)) < int(contest_number):
            insert_pos = search_start + m.start()
            # Step back to include the blank line before the entry
            while insert_pos > search_start and content[insert_pos - 1] == "\n":
                insert_pos -= 1
            break

    content = content[:insert_pos] + new_entry + content[insert_pos:]

    with open(readme_path, "w", encoding="utf-8") as f:
        f.write(content)

    print(f"Updated README.md with {contest_label} Contest {contest_number}")


def main():
    if len(sys.argv) != 2:
        print("Please provide a valid contest number.")
        sys.exit(1)

    contest_arg = sys.argv[1]

    # Determine contest type and number
    if contest_arg.startswith("b"):
        contest_type = "biweekly"
        contest_number = contest_arg[1:]
    else:
        contest_type = "weekly"
        contest_number = contest_arg

    # Get absolute paths
    current_dir = os.path.abspath(os.getcwd())
    target_dir = os.path.join(current_dir, "contests", contest_type, contest_number)
    if os.path.exists(target_dir):
        print("Existing contest folder.")
        sys.exit(1)

    # Create directory and files
    os.makedirs(target_dir, exist_ok=True)
    for i in range(1, 5):
        file_path = os.path.join(target_dir, f"Q{i}.cs")
        open(file_path, "w").close()

    # Clear input and output files
    open("input.txt", "w").close()
    open("output.txt", "w").close()

    # Update README.md
    readme_path = os.path.join(current_dir, "README.md")
    update_readme(readme_path, contest_type, contest_number)

    # Close all tabs then open all files in VSCode in one command
    files_to_open = [readme_path, "output.txt", "input.txt"] + [
        os.path.join(target_dir, f"Q{i}.cs") for i in range(4, 0, -1)
    ]
    try:
        editor = os.environ.get("LEETCODE_EDITOR", "none")
        if editor == "none":
            pass
        elif editor == "code":
            cmd = "code -r " + " ".join(f'"{f}"' for f in files_to_open)
            subprocess.run(cmd, shell=True, check=True)
        else:
            subprocess.run([editor] + files_to_open, check=True)
    except subprocess.CalledProcessError as e:
        print(f"Failed to open editor: {e}")
    except Exception as e:
        print(f"Unexpected error: {e}")


if __name__ == "__main__":
    main()
