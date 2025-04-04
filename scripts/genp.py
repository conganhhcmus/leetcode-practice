import os
import sys
import subprocess

def update_global_using(new_running):
    # Read all lines from the file
    with open("GlobalUsing.cs", "r") as f:
        lines = f.readlines()
    
    # Update first line, keep others unchanged
    lines[0] = f"global using Running = Problems_{new_running};\n"
    
    # Write back all lines
    with open("GlobalUsing.cs", "w") as f:
        f.writelines(lines)

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
    with open(solution_path, 'w') as f:
        f.write("")  # Create an empty file

    # Update only the first line of GlobalUsing.cs
    update_global_using(problem_name)

    # Clear testcase and answer files
    open("testcase.txt", 'w').close()
    open("answer.txt", 'w').close()

    # Ensure file exists and try to open it in VS Code
    if os.path.exists(solution_path):
        try:
            # Use shell=True to let the shell resolve the command
            cmd = f'code -r "{solution_path}"'
            subprocess.run(cmd, shell=True, check=True)
        except subprocess.CalledProcessError as e:
            print(f"Failed to open VS Code: {e}")
            print(f"File created at: {solution_path}")
        except Exception as e:
            print(f"Unexpected error: {e}")
            print(f"File created at: {solution_path}")
    else:
        print(f"File creation failed at: {solution_path}")

if __name__ == "__main__":
    main() 