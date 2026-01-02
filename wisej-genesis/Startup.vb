Imports Microsoft.AspNetCore.Builder
Imports Wisej.Core

''' <summary>
''' The Startup class configures services and the app's request pipeline.
''' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
''' </summary>
Public Class Startup

    Public Shared Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(New WebApplicationOptions With {
            .args = args,
            .WebRootPath = "./"
        })


        Dim app = builder.Build()

        ' Add Wisej.
        app.UseWisej()

        ' Add FileServer middleware to serve content files excluding .json files.
        app.UseWhen(
                    Function(context) Not context.Request.Path.Value.EndsWith(".json", StringComparison.InvariantCulture),
                    Sub(appBuilder) appBuilder.UseFileServer())

        app.Run()
    End Sub

End Class
