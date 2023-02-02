Youtube source: https://www.youtube.com/watch?v=3_AsedRrqww&list=PL4LFuHwItvKbdK-ogNsOx2X58hHGeQm8c

Starting application outside Visual Studion environment:

1. Open 2 console instances or 2 Windows Terminal tabs

2. Position both your consoles or Windows Terminal tabs to the directory where your solution file (ShopOnline.sln) is checked-out

3. 
    a. In first tab type command: "dotnet run --project .\ShopOnline.Api seed" (without quotes) to start API project
    b. In second tab type: "dotnet run --project .\ShopOnline.Web" (without quotes) to start web application

4. Open web browser and navigate to the path where ShopOnline.Web application is listening.

