# Amplifier - .NET Core SaaS Application Toolkit

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/859efffe507c473fbdca2960fe4a73a8)](https://app.codacy.com/app/FabriDamazio/amplifier?utm_source=github.com&utm_medium=referral&utm_content=FabriDamazio/amplifier&utm_campaign=Badge_Grade_Dashboard)
[![Join the chat at https://gitter.im/amplifier-saas-toolkit/community](https://badges.gitter.im/amplifier-saas-toolkit/community.svg)](https://gitter.im/amplifier-saas-toolkit/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![CodeFactor](https://www.codefactor.io/repository/github/fabridamazio/amplifier/badge/master)](https://www.codefactor.io/repository/github/fabridamazio/amplifier/overview/master)
[![Build Status](https://travis-ci.com/FabriDamazio/amplifier.svg?branch=master)](https://travis-ci.com/FabriDamazio/amplifier)

Amplifier is a toolkit for building .NET Core Software As A Service (SaaS) applications.

Easy integration with your new/existing project or you can use the [Amplifier Starter](https://github.com/FabriDamazio/amplifier-starter) template.

Full documentation is available at [documentation website](https://fabridamazio.github.io/amplifier/)  ** **Under Construction** **

## Quick Start

Amplifier is available through NuGet packages at [Nuget.org](https://www.nuget.org/)

### Installation

For now, we only support .Net Core projects using Entity Framework Core and ASP.NET Core Identity:

```bash
PM> Install-Package Amplifier.AspNetCore
PM> Install-Package Amplifier.EntityFrameworkCore
```

### Configuration

Add Amplifier in `Startup.cs`:

```csharp
  public void ConfigureServices(IServiceCollection services)
    {
        //...
        services.AddAmplifier();
        //...
    }
```

```csharp
  public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        //...
        app.UseAmplifier<int>();
        //...
    }
```

Project DbContext needs inherit from `IdentityDbContextBase<TTenant, TUser, TRole, TKey>`:

```csharp
   public class ApplicationDbContext : IdentityDbContextBase<Tenant, User, Role, int>
    {
        private readonly IUserSession<int> _userSession;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserSession<int> userSession)
            : base(options, userSession)
        {
            _userSession = userSession;
        }

        // DbSets....
    }
```

Project `User` class needs inherit from `IdentityUser`, the `Tenant` class from `TenantBase` and the `Role` class from `IdentityRole`.

### Using

Just Apply these interfaces:

- `IMayHaveTenant` - for classes that may have a Tenant Id.
- `IHaveTenant` - for classes that have Tenant Id.
- `ITenantFilter` - for classes that should be filtered by Tenant Id.
- `IFullAuditedEntity` - for classes that needs be audited (creation, deletion and last modified time and user).
- `ISoftDelete` - for classes that should be soft deleted.

## Contributing

Please read [CONTRIBUTING.md](https://github.com/FabriDamazio/amplifier/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/FabriDamazio/amplifier/tags).

## Authors

- [**Fabri Damazio**](https://github.com/FabriDamazio) - fabridamazio@gmail.com
