# DevSkillHQ-BE API

## Usage

### 1. using Makefile

download dependencies

```bash
make restore
```

build and run docker image:

```bash
make docker
```

run server in watch mode

```bash
make server
```

To run test:

```bash
make test
```

# OR using dotnet cli

to download dependencies:

```bash
dotnet restore
```

to run api:

```bash
dotnet run
```

to run api in watch mode:

```bash
dotnet watch run
```

To run test:
make sure you in the DevSkillHQ-BE.Test directory

download dependencies:

```bash
dotnet restore
```

run test:

```bash
dotnet test
```
