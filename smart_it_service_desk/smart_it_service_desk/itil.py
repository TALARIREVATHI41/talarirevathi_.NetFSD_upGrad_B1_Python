import json

class ProblemManagement:
    FILE = "data/problems.json"

    def repeated_issue_analysis(self, tickets):
        issues = {}

        for t in tickets:
            issues[t["issue"]] = issues.get(t["issue"], 0) + 1

        problems = []

        for issue, count in issues.items():
            if count >= 5:
                problems.append({
                    "issue": issue,
                    "occurrences": count
                })

        with open(self.FILE, "w") as f:
            json.dump(problems, f, indent=4)

        return problems