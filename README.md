# **Combination: .Net core pdf report by razor html and DinkToPdf**

## 1. Introduction  
    I was struggling in building a pdf report using .Net core. What I've tried was using some pdf frameworks to build the report. But it was very difficult to learn the framework langugue to build and customize my report.   

    Then I come out with solution generate pdf report from html content. which I use DinkToPdf because it is free and cross platform supportted.  

    But then I faced another problem is how to generate html report with binding data in an organized way instead of string combination. I found .net core Razor is a very powerful framework for .net core html generation. It support MVVM binding with html syntax and c# code. It's especially useful for people who are familiar with MVVM in .Net framework like me.

    In this project, I combine code from some source from other authors to make whole pdf report feature work.

## 2. Explain Code  
###    2.1. Render report html using razor
- Razor syntax is supported default by .net core. I just need to create rendering service to render html from razor view and viewModel.  
- I took service class HtmlViewToStringRendererService written in https://dotnetstories.com/blog/Generate-a-HTML-string-from-cshtml-razor-view-using-ASPNET-Core-that-can-be-used-in-the-c-controlle-7173969632  
- Add following binding to startup.cs to be able to user service:
> // For pdf report  
>    services.AddTransient<HtmlViewToStringRendererService, HtmlViewToStringRendererService>();
>    services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
>    services.AddMvc();  

- Create ViewModel, View by razor syntax. Here I create TestPdfReportViewModel.cs and TestPdfReportView.cshtml
- Now, I can inject HtmlViewToStringRendererService and call method RenderViewToStringAsync to render report into html format. 

###   2.2. Convert html report to pdf with DinkToPDF
- Install dinkToPdf package from nuget
- DinkToPDF depends on library libwkhtmltox. there are 3 files for 3 platform: libwkhtmltox.**dll** for window, libwkhtmltox.**dylib** for OSX, libwkhtmltox.**so** for linux. We have to check to load corresponding library file on startup.
- HtmlToPdfConverter implement the call to convert html to pdf byte array, which we can use to return as a pdf file.