[![Build.Mvc](https://download-codeplex.sec.s-msft.com/Download?ProjectName=buildmvc&DownloadId=316912&Build=20907 "Build.Mvc")](https://buildmvc.codeplex.com/)
=========

Build.Mvc is a helper extensions method library that turns the standard ASP .NET MVC HtmlHelper methods into jQuery-style chainable methods that allow you to expressively add markup and style to your MVC application.

**Build.Mvc is available on [NuGet](https://www.nuget.org/packages?q=Build.Mvc)**

## Build.Mvc let's you change this:

```
@if (Model.DateOfBirth.HasValue)
{ 
    @Html.TextBoxFor(m => m.DateOfBirth, String.Format("{0:d}", Model.DateOfBirth) ,new { @class = "ui-datepicker span11", @style = "display:block;float:left;" })
}
else
{ 
    @Html.TextBoxFor(m => m.DateOfBirth, new { @value = "", @class = "ui-datepicker span11", @style = "display:block;float:left;" ,@readonly="readonly"})
}
```

## Into this:
```
@Html.BuildTextBoxFor(m => m.DateOfBirth, string.Format("{0:d}", Model.DateOfBirth)).BuildWith(
    b => b.AddClass("ui-datepicker", "span11").
        Css("display", "block").
        Css("float", "left").
        BuildWhen(Model.DateOfBirth == null, t =>
            t.Attr("value", "").
              Attr("readonly", "readonly")
        ))
```


View the project on [CodePlex](https://buildmvc.codeplex.com/documentation) for more complete documentation.

### Reference and Example Apps ###

1. [SocialGoal](https://github.com/grcodemonkey/SocialGoal) is a MVC 5, EF6 Reference App
