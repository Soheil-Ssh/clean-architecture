# 🏛 Clean Architecture Sample (.NET 10)

[![.NET](https://img.shields.io/badge/.NET-10-purple)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green)]()
[![Architecture](https://img.shields.io/badge/Architecture-Clean-blue)]()

یکی از چالش‌های همیشگی برنامه‌نویسان در درک **معماری تمیز (Clean Architecture)**، نبود یک رویکرد واحد و وجود پیاده‌سازی‌های سلیقه‌ای است. دیدن یک نمونه‌ی ساده ولی کامل، به درک بهتر این معماری و الگوهای آن کمک می‌کند.
به همین دلیل، تصمیم گرفتم این پروژه را به عنوان یک نمونه‌ی استاندارد و قابل فهم در گیت‌هاب قرار دهم.

![Clean Architecture](./clean_architecture.png "Clean Architecture")

## 📚 در این پروژه چه چیزهایی یاد خواهید گرفت؟

- نحوه ساختاربندی یک پروژه بر اساس معماری تمیز (Clean Architecture)
- پیاده‌سازی الگوی CQRS برای جداسازی عملیات خواندن و نوشتن
- استفاده از الگوهای Repository و Unit Of Work
- پیاده‌سازی Result Pattern برای مدیریت خطاها و نتایج عملیات
- سازمان‌دهی وابستگی‌ها بین لایه‌های مختلف سیستم
- توسعه APIهای قابل نگهداری و توسعه‌پذیر با ASP.NET Core

## 📋 ویژگی‌ها

این پروژه یک پیاده‌سازی کاربردی از معماری تمیز است که از الگوها و تکنولوژی‌های زیر بهره می‌برد:

- Clean Architecture
- CQRS (Commands & Queries)
- Repository Pattern
- Unit Of Work
- Result Pattern
- Fluent Validation
- Entity Framework Core
- SQL Server
- Global Exception Handling
- Scalar API Documentation
- SOLID Principles

## 📋 دامنه پروژه

برای حفظ سادگی پروژه، یک سیستم «مدیریت کارها» (Task Manager) بسیار ساده در نظر گرفته شده است که موجودیت اصلی آن `ToDo` می‌باشد:

```csharp
public class ToDo : BaseEntity<long>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedDate { get; set; }
}
```

نکته: بدیهی است که رویکرد دسترسی به داده‌ها در دیتابیس‌های دیگر (مثل MongoDB یا PostgreSQL) نیز از نظر معماری به همین شکل است و صرفاً به تغییر پیاده‌سازی در لایه‌ی Infrastructure نیاز دارد.

##  🏗 ساختار پروژه

ساختار لایه‌های پروژه به شکل زیر است:

```plaintext
Src
├── CleanArch.Api
├── CleanArch.Application
├── CleanArch.Core
├── CleanArch.Infrastructure
```

### 1. لایه Core (هسته سیستم)

این لایه قلب اپلیکیشن محسوب می‌شود و نباید به هیچ‌یک از لایه‌های دیگر وابسته باشد. تمامی قوانین و مفاهیم اصلی دامنه در این لایه قرار می‌گیرند.

موارد موجود در این لایه عبارت‌اند از:

- Entities
- Domain Abstractions (مانند Result Pattern و Errorها)
- Specifications
- Interfaces
- Value Objects و سایر مفاهیم دامنه

> در این پروژه برای حفظ سادگی و تمرکز بر معماری تمیز، برخی مفاهیم پیشرفته Domain-Driven Design مانند Value Objectها پیاده‌سازی نشده‌اند.

### 2. لایه Application

این لایه شامل پیاده‌سازی Use Caseهای سیستم است و منطق اجرای عملیات‌های مختلف در آن قرار می‌گیرد.

- Commands & Queries
- Command / Query Handlers
- Command / Query Validators
- Mapping Profiles
- Pipeline Behaviors
- DTOs

این لایه تنها به لایه Core وابسته است و از Interfaceها و Abstractionهای تعریف‌شده در Core استفاده می‌کند.

### 3. لایه Infrastructure

تمام ارتباطات با سرویس‌های خارجی در این لایه پیاده‌سازی می‌شوند. در واقع Interfaceهایی که در لایه Core یا Application تعریف شده‌اند، در این لایه پیاده‌سازی می‌شوند.

- Repository Implementations
- Unit of work
- Entity Framework Core
- DbContext
- External Services

این موضوع باعث می‌شود جزئیات فنی زیرساخت از منطق اصلی سیستم جدا بماند.

### 4. لایه Presentation (API)

این لایه نقطه ورود کاربران یا کلاینت‌ها به سیستم است. بسته به نوع پروژه می‌تواند یک Web API، برنامه وب، اپلیکیشن موبایل، دسکتاپ یا هر نوع رابط کاربری دیگری باشد.

در این پروژه، لایه Presentation به صورت یک ASP.NET Core Web API پیاده‌سازی شده است.

این لایه درخواست‌ها را دریافت کرده و با استفاده از Use Caseهای موجود در Application عملیات موردنظر را اجرا می‌کند. در نتیجه هیچ وابستگی مستقیمی به جزئیات پیاده‌سازی زیرساخت نخواهد داشت.

## ⚠️ نکات مهم

1. برای جلوگیری از پیچیدگی غیرضروری و تمرکز بر مفاهیم اصلی Clean Architecture، از برخی مفاهیم پیشرفته DDD مانند Domain Events، Aggregate Roots، Domain Validation و Value Objects صرف‌نظر شده است.
2. این پروژه با استفاده از Controllerها پیاده‌سازی شده و از Minimal API استفاده نمی‌کند. هر دو رویکرد در این معماری قابل استفاده هستند، اما در این نمونه استفاده از Controllerها ترجیح داده شده است.
3. به منظور حفظ سادگی پروژه، پیکربندی Docker در نظر گرفته نشده است.
4. مواردی مانند Rate Limiting، CORS، Authentication و Authorization در این پروژه پیاده‌سازی نشده‌اند؛ زیرا تمرکز اصلی پروژه بر نمایش ساختار و مفاهیم Clean Architecture بوده است، نه جزئیات توسعه Web API.

## 🚀 راهنمای اجرا

### پیش‌نیازها
- دات نت 10
- یک نمونه از Sql server (LocalDB یا دیتابیس اصلی)

### ۱. دریافت و آماده‌سازی پروژه

ابتدا پروژه را کلون کنید. سپس برای دریافت پکیج‌ها، در Visual Studio روی Solution کلیک راست کرده و Rebuild را بزنید.
اگر از `dotnet cli` استفاده می‌کنید، وارد پوشه‌ی اصلی پروژه شده و دستور زیر را وارد کنید:

```bash
dotnet restore
```

### ۲. تنظیمات دیتابیس

کانکشن استرینگ (Connection String) مربوط به دیتابیس SQL Server در فایل `appsettings.json` لایه‌ی API قرار دارد. آن را بر اساس تنظیمات نمونه دیتابیس خود تغییر دهید.

### ۳. اعمال تغییرات دیتابیس

در محیط `dotnet cli`:
در پوشه‌ی اصلی پروژه، دستور زیر را اجرا کنید تا دیتابیس ساخته شود:

```bash
dotnet ef database update --project Src/CleanArch.Infrastructure --startup-project Src/CleanArch.Api
```

در محیط Visual Studio (Package Manager Console):
ابتدا لایه‌ی `Infrastructure` (یا لایه‌ای که فایل‌های دیتابیس در آن است) را به عنوان Default project انتخاب کرده و دستور زیر را اجرا کنید:

```bash
Update-Database
```

### ۴. اجرای پروژه

در Visual Studio با زدن کلید F5 و در dotnet cli با دستور زیر می‌توانید پروژه را اجرا کنید:

```bash
dotnet run --project Src/CleanArch.Api
```

بعد از اجرای پروژه می‌تواند با استفاده از Scalar که در آدرس https://localhost:port/scalar موجود است Endpoint ها را تست کنید.