#pragma checksum "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60c2d7d8ba90a5b05f39cd9e40f6e4cdd3cde31d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\_ViewImports.cshtml"
using One_to_many_migration.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\_ViewImports.cshtml"
using One_to_many_migration.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\_ViewImports.cshtml"
using FiorelloHomeWork.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\_ViewImports.cshtml"
using FiorelloHomeWork.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60c2d7d8ba90a5b05f39cd9e40f6e4cdd3cde31d", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de7d749cf1164043f1240ae89b051bdaf1784ee0", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- PRODUCTS START -->\r\n\r\n<section id=\"products\">\r\n    <div class=\"container\">      \r\n        <div class=\"row parent\">\r\n            ");
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\Product\Index.cshtml"
       Write(await Component.InvokeAsync("Product",12));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n        <div class=\"row my-3 justify-content-center\">\r\n            <input type=\"hidden\" id=\"productCount\"");
            BeginWriteAttribute("value", "  value=\"", 1243, "\"", 1273, 1);
#nullable restore
#line 33 "C:\Users\ASUS\Desktop\FiorelloReadMoreButton\FiorelloHomeWork\Views\Product\Index.cshtml"
WriteAttributeValue("", 1252, ViewBag.ProductCount, 1252, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <button class=\"btn btn-dark\" id=\"readmore\">Read more ...</button>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<!-- PRODUCTS END -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
