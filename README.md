# Json2Env


## Introduction

A command line tool that converts Json configuration files to .env files (Environment variables) suitable for docker containers, etc.

### Usage

#### Note
- Current support for windows OS
- .NET 6 and above must be installed on the machine `important`

- Clone the repo
- Navigate to the project folder and open in cmd
- Run the CLI tool and pass the compulsory filepath

```bash
Json2Env.exe filepath [options]
```

#### Options
- "--s" `Optional` pass "u" or "c" to use either underscores or columns as seperator, defualt is underscore
- "--output" `Optional` pass a name you want to to store the .env file as , e.g "appconfig"

# ![Appsettings](https://github.com/khelechy/Json2Env/blob/main/appsettings.PNG)

Command

```bash
Json2Env.exe C:\Users\konyekwere\source\repos\Test\appsettings.json --s C --output appconfig
```

# ![AppComgif](https://github.com/khelechy/Json2Env/blob/main/appconfig.PNG)

>**NOTE**
- Generated .env files are stored in the "c:\Json2Env\output folder" `important`

## Contribution
Feel like something is missing? Fork the repo and send a PR.

Encountered a bug? Fork the repo and send a PR.

Alternatively, open an issue and we'll get to it as soon as we can.