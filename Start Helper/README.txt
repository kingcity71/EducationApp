1. Создание миграций БД
dotnet ef migrations add Initial --context EduContext --project Education.Data --startup-project Education.WebApp

2. Применение
dotnet ef database update --context EduContext --project Education.Data --startup-project Education.WebApp

3. Запустить скрипты из папки Start Helper