#pragma checksum "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\ClientAvto\GetOnly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82389aced2ea379590b1674a28e88a62df3f3f47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClientAvto_GetOnly), @"mvc.1.0.view", @"/Views/ClientAvto/GetOnly.cshtml")]
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
#line 1 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\_ViewImports.cshtml"
using CarStoreWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\_ViewImports.cshtml"
using CarStoreWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82389aced2ea379590b1674a28e88a62df3f3f47", @"/Views/ClientAvto/GetOnly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"222bd0d77ff2f852c5194ddeb2597a6cf966141b", @"/Views/_ViewImports.cshtml")]
    public class Views_ClientAvto_GetOnly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarStoreWebApp.Models.Car>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 90, "\"", 106, 1);
#nullable restore
#line 5 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\ClientAvto\GetOnly.cshtml"
WriteAttributeValue("", 96, Model.Img, 96, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:500px;\" />\r\n    </div>\r\n    <div class=\"col\">\r\n        <div class=\"container\">\r\n            <div class=\"form-group\">\r\n                <b style=\"font-size:17px\">Модель:</b>  ");
#nullable restore
#line 10 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\ClientAvto\GetOnly.cshtml"
                                                  Write(Model.Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <b style=\"font-size:17px\">Статус:</b> ");
#nullable restore
#line 13 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\ClientAvto\GetOnly.cshtml"
                                                 Write(Model.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <p>\r\n                    <b style=\"font-size:17px\">Описание:</b>  ");
#nullable restore
#line 17 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\ClientAvto\GetOnly.cshtml"
                                                        Write(Model.Desciption);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <b style=\"font-size:17px\">Цена:</b> ");
#nullable restore
#line 21 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\ClientAvto\GetOnly.cshtml"
                                               Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" сом\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarStoreWebApp.Models.Car> Html { get; private set; }
    }
}
#pragma warning restore 1591