import os
import sys
import subprocess


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
    q1_path = os.path.join(target_dir, "Q1.cs")

    if os.path.exists(target_dir):
        print("Existing contest folder.")
        sys.exit(1)

    # Create directory and files
    os.makedirs(target_dir, exist_ok=True)
    for i in range(1, 5):
        file_path = os.path.join(target_dir, f"Q{i}.cs")
        with open(file_path, "w") as f:
            f.write("")

    # Clear input and output files
    open("input.txt", "w").close()
    open("output.txt", "w").close()

    # Ensure file exists and try to open it in VSCode
    if os.path.exists(q1_path):
        try:
            # Use shell=True to let the shell resolve the command
            cmd = f'code -r "{q1_path}"'
            subprocess.run(cmd, shell=True, check=True)
        except subprocess.CalledProcessError as e:
            print(f"Failed to open VSCode: {e}")
            print(f"Files created in: {target_dir}")
        except Exception as e:
            print(f"Unexpected error: {e}")
            print(f"Files created in: {target_dir}")
    else:
        print(f"File creation failed at: {q1_path}")


if __name__ == "__main__":
    main()
