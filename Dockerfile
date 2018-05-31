FROM microsoft/dotnet:2.1-sdk
FROM microsoft/aspnetcore:1.1.2
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./

ENV ASPNETCORE_URLS="http://*:5555"
EXPOSE 5555/tcp
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/ChatSample.dll"]
