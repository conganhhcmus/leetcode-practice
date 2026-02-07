import os
import sys
import subprocess


def main():
    if len(sys.argv) != 2:
        print("Please provide a valid problem name.")
        sys.exit(1)

    problem_name = sys.argv[1]
    # Get absolute paths
    current_dir = os.path.abspath(os.getcwd())
    target_dir = os.path.join(current_dir, "problems", problem_name)
    solution_path = os.path.join(target_dir, "Solution.cs")

    if os.path.exists(target_dir):
        print("Existing problem folder.")
        sys.exit(1)

    # Create directory and solution file
    os.makedirs(target_dir, exist_ok=True)
    open(solution_path, "w").close()

    # Clear input and output files
    open("input.txt", "w").close()
    open("output.txt", "w").close()

    # Open all files in VSCode (last opened gets focus)
    files_to_open = [
        "output.txt",
        "input.txt",
        solution_path,
    ]
    for file_path in files_to_open:
        try:
            cmd = f'code -r "{file_path}"'
            subprocess.run(cmd, shell=True, check=True)
        except subprocess.CalledProcessError as e:
            print(f"Failed to open VSCode: {e}")
        except Exception as e:
            print(f"Unexpected error: {e}")


if __name__ == "__main__":
    main()
