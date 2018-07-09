#Install packages

<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="2.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.1.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.1.1" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.1.1" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL.Design" Version="1.1.1" />
  </ItemGroup>


  <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.3" />
  </ItemGroup>

#run cli command
dotnet ef dbcontext scaffold "User ID=username;Password=userpassword;Server=servername;Port=5432;Database=dbname;Pooling=true;" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f -c PostgreDbContext
