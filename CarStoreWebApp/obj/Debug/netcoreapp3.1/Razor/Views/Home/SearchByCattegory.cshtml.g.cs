#pragma checksum "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62cf5ca40fb2c95ff6670191955021c996be49ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SearchByCattegory), @"mvc.1.0.view", @"/Views/Home/SearchByCattegory.cshtml")]
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
#line 1 "D:\CarStore\CarStore\CarStoreWebApp\Views\_ViewImports.cshtml"
using CarStoreWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CarStore\CarStore\CarStoreWebApp\Views\_ViewImports.cshtml"
using CarStoreWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62cf5ca40fb2c95ff6670191955021c996be49ec", @"/Views/Home/SearchByCattegory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"222bd0d77ff2f852c5194ddeb2597a6cf966141b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SearchByCattegory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarStoreWebApp.Models.Car>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ClientAvto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetOnly", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62cf5ca40fb2c95ff6670191955021c996be49ec3815", async() => {
                WriteLiteral(@"
    <script>
        function AddToCart(id) {
            $.post(""/ClientCart/AddCart"", { id: id })
                .done(function (data) {
                    alert(""Ваш товар успешно был добавлен в карзину!"");
                })
        }
    </script>
    <table class=""table"">
        <thead>
            <tr>
                <th><d>Фото</d></th>
                <th><d>Модель</d></th>
                <th><d>Название</d></th>
                <th><d>Цена</d></th>
                <th><d>Добавление</d></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 22 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
             foreach (var x in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62cf5ca40fb2c95ff6670191955021c996be49ec4949", async() => {
                    WriteLiteral("<img");
                    BeginWriteAttribute("src", " src=\"", 806, "\"", 818, 1);
#nullable restore
#line 25 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
WriteAttributeValue("", 812, x.Img, 812, 6, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" style=\"width:150px;\" />");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
                                                                              WriteLiteral(x.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
                   Write(x.Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
                   Write(x.Category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 27 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
                                    Write(x.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
                   Write(x.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" сом</td>\r\n                    <td><button");
                BeginWriteAttribute("onclick", " onclick=\"", 1027, "\"", 1053, 3);
                WriteAttributeValue("", 1037, "AddToCart(", 1037, 10, true);
#nullable restore
#line 29 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
WriteAttributeValue("", 1047, x.Id, 1047, 5, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1052, ")", 1052, 1, true);
                EndWriteAttribute();
                WriteLiteral(" class=\" btn  btn-success\">Добавить в корзину</button></td>\r\n                </tr>\r\n");
#nullable restore
#line 31 "D:\CarStore\CarStore\CarStoreWebApp\Views\Home\SearchByCattegory.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarStoreWebApp.Models.Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591
