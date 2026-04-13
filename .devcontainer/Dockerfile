FROM mcr.microsoft.com/devcontainers/dotnet:8.0

# Install system dependencies
RUN apt-get update \
    && apt-get install -y openssh-client \
    && rm -rf /var/lib/apt/lists/*

# Install dotnet tools
RUN dotnet tool install --global dotnet-ef

# Ensure tools are in PATH
ENV PATH="$PATH:/root/.dotnet/tools"
