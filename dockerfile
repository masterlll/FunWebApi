# FROM microsoft/dotnet:2.1-sdk AS build
# WORKDIR /app
# # copy csproj and restore as distinct layers
# COPY *.csproj .
# RUN dotnet restore

# # copy everything else and build app
# COPY . .
# WORKDIR /app
# RUN dotnet publish -c Release -o out


# FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
# WORKDIR /app
# COPY --from=build /app/out ./
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]

# FROM microsoft/dotnet:2.1-sdk

# COPY . .

# ENTRYPOINT ["dotnet", "console.dll"]


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY ./bin .
ENV ASPNETCORE_URLS=http://+:4000 \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true
ENTRYPOINT ["dotnet", "FunWebApi.dll"]

