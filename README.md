# 📅 CronSchedular

A **cron job scheduler** is a time-based job scheduler found in Unix-like operating systems (Linux, macOS). It allows users to **automate repetitive tasks** by executing commands or scripts at specified intervals or specific times.

> 📖 Learn more: [Cron – Wikipedia](https://en.wikipedia.org/wiki/Cron)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
  git clone git@github.com:beautisui/CronSchedular.git
  cd CronSchedular
````

### 2. Run the Scheduler

```bash
dotnet run "* * * * *" "<command to execute>"
```

Replace `* * * * *` with your cron expression and `<command to execute>` with the actual command/script.

---

## ⏱ Cron Expression Format

A cron expression has **five space-separated fields**, in the following order:

```
* * * * *
| | | | |
| | | | +---- Day of the week (0–6) (Sunday to Saturday; 7 is also Sunday on some systems)
| | | +------ Month (1–12)
| | +-------- Day of the month (1–31)
| +---------- Hour (0–23)
+------------ Minute (0–59)
```

### 🧪 Example

```bash
dotnet run "0 9 * * 1" "echo 'Hello, it's Monday 9 AM!'"
```

This will run the command every **Monday at 9:00 AM**.

---
