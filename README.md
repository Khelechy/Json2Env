# Json2Env


## Introduction

A command line tool that converts Json configuration files to .env files (Environment variables) suitable for docker containers, etc.

### Usage

>**NOTE**
>Currently supports windows OS


Run the CLI tool and pass the compulsory filepath

```bash
Json2Env filepath [options]
```

#### Options
- "--s" `Optional` pass "u" or "c" to use either underscores or columns as seperator, defualt is underscore
- "--output" `Optional` pass a name you want to to store the .env file as , e.g "appconfig"

```bash
Json2Env C:\Users\konyekwere\source\repos\Test\appsettings.json --s c --output appconfig
```

>**NOTE**
>Generated .env files are stored in the c:\Json2Env\output folder 