import os
import re

README_PATH = "../README.md"
STATS_SECTION_START = "<!-- start -->"
STATS_SECTION_END = "<!-- end -->"

def calculate_stats():
    problems_dir = "../problems"
    weekly_contests_dir = "../contests/weekly"
    biweekly_contests_dir = "../contests/biweekly"

    total_problems = len(os.listdir(problems_dir)) if os.path.exists(problems_dir) else 0
    weekly_contests = len(os.listdir(weekly_contests_dir)) if os.path.exists(weekly_contests_dir) else 0
    biweekly_contests = len(os.listdir(biweekly_contests_dir)) if os.path.exists(biweekly_contests_dir) else 0

    return {
        "total_problems": total_problems,
        "weekly_contests": weekly_contests,
        "biweekly_contests": biweekly_contests
    }

def update_stats():
    stats = calculate_stats()
    with open(README_PATH, "r", encoding="utf-8") as file:
        readme_content = file.read()

    stats_section = (
        f"{STATS_SECTION_START}\n"
        f"## 🚀 Stats\n"
        f"- Total Problems Solved: {stats['total_problems']}\n"
        f"- Weekly Contests Participated: {stats['weekly_contests']}\n"
        f"- Biweekly Contests Participated: {stats['biweekly_contests']}\n"
        f"{STATS_SECTION_END}"
    )

    updated_content = re.sub(
        f"{re.escape(STATS_SECTION_START)}[\\s\\S]*?{re.escape(STATS_SECTION_END)}",
        stats_section,
        readme_content
    )

    with open(README_PATH, "w", encoding="utf-8") as file:
        file.write(updated_content)

    print("README.md updated stats successfully!")

if __name__ == "__main__":
    update_stats()
