---
applyTo: "**"
---
# Conventional Commits 1.0.0

A lightweight convention on commit messages that:

* Communicates intent of the change.
* Facilitates automated CHANGELOG generation, release notes, and semantic versioning.

This specification aligns commit messages with Semantic Versioning.

---

## 1. Commit Message Format

```
<type>[optional scope][!]: <description>

[optional body]

[optional footer(s)]
```

* `<type>`: the commit category (e.g., `feat`, `fix`).
* `[optional scope]`: a noun describing location in codebase, in parentheses.
* `[!]`: an optional bang to denote a breaking change.
* `<description>`: a short, imperative summary.
* `[optional body]`: detailed explanation; separated by a blank line.
* `[optional footer(s)]`: metadata; separated by a blank line.

---

## 2. Types

Common types (recommended, but not enforced):

* **feat**: a new feature (correlates with MINOR version bump in SemVer).
* **fix**: a bug fix (correlates with PATCH in SemVer).
* **build**: changes affecting build system or external dependencies (example scopes: gulp, broccoli, npm).
* **ci**: changes to CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs).
* **docs**: documentation only changes.
* **style**: formatting, whitespace, semicolons, etc.; no code change.
* **refactor**: code change that neither fixes a bug nor adds a feature.
* **perf**: code change that improves performance.
* **test**: adding missing or correcting existing tests.
* **chore**: other changes that don’t modify src or test files.

---

## 3. Scope

A scope provides additional contextual information. It is a noun describing a section of the codebase enclosed in parentheses:

```
feat(parser): add ability to parse arrays
```

---

## 4. Description

* Must be short and imperative, e.g., `fix: correct minor typos in code`.
* No trailing period.

---

## 5. Body

* Provides the motivation for the change and contrasts with the previous behavior.
* Should begin after one blank line.

---

## 6. Footer

* One or more footers may follow after one blank line.
* Footers consist of a token (case-sensitive), a colon, and a description.

Common footer tokens:

* `BREAKING CHANGE:` A description of a breaking API change.
* `Closes:` Closes related issues, e.g., `Closes #123`.

---

## 7. Breaking Changes

Breaking changes must be indicated in one of two ways:

1. Append `!` after the type or scope in the header:

   ```
   feat!: drop support for Node 6
   ```

2. Include `BREAKING CHANGE:` in the footer or body:

   ```
   feat: allow provided config object to extend other configs

   BREAKING CHANGE: `extends` key in config file now extends other configs
   ```

In both cases, a description is required.

---

## 8. Examples

### 8.1. Commit message with description and breaking change footer

```
feat: allow provided config object to extend other configs

BREAKING CHANGE: `extends` key in config file is now used for extending other config files
```

### 8.2. Commit message with `!` to draw attention to breaking change

```
feat!: send an email to the customer when a product is shipped
```

### 8.3. Commit message with scope and `!`

```
feat(api)!: send an email to the customer when a product is shipped
```

### 8.4. Commit message with both `!` and BREAKING CHANGE footer

```
chore!: drop support for Node 6

BREAKING CHANGE: use JavaScript features not available in Node 6.
```

### 8.5. Commit message with no body

```
docs: correct spelling of CHANGELOG
```

### 8.6. Commit message with scope

```
feat(lang): add Polish language
```

### 8.7. Commit message with multi-paragraph body and multiple footers

```
fix: prevent racing of requests

Introduce a request id and reference to latest request. Dismiss
incoming responses other than from latest request.

Remove timeouts which were used to mitigate the racing issue but are
obsolete now.

Reviewed-by: Z
Refs: #123
```

---

*For full details, see ********[Conventional Commits 1.0.0](https://www.conventionalcommits.org/en/v1.0.0/)********.*
