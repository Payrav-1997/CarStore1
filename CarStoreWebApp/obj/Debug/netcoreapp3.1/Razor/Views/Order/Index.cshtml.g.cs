#pragma checksum "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49ab7306e3e8344adaea40c9bc851e5c179190f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49ab7306e3e8344adaea40c9bc851e5c179190f6", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"222bd0d77ff2f852c5194ddeb2597a6cf966141b", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarStoreWebApp.Models.Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Фото</th>\r\n            <th>Имя</th>\r\n            <th>Количество</th>\r\n            <th>Цена</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
         foreach (var x in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><img");
            BeginWriteAttribute("src", " src=\"", 335, "\"", 357, 1);
#nullable restore
#line 15 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
WriteAttributeValue("", 341, x.Item.Item.Img, 341, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:150px\" /></td>\r\n                <td>");
#nullable restore
#line 16 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
               Write(x.Item.Item.Category);

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
                                    Write(x.Item.Item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 17 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
               Write(x.Item.Caunt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 18 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
               Write(x.Item.Item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" сом</td>\r\n            </tr>\r\n");
#nullable restore
#line 20 "C:\Users\LENOVO\Desktop\CarStore\CarStoreWebApp\Views\Order\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarStoreWebApp.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591