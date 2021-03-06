#pragma checksum "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f71dfced6b00e05b11e8523b66034ce5cfe65032"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Order_OrderPickup), @"mvc.1.0.view", @"/Areas/Customer/Views/Order/OrderPickup.cshtml")]
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
#line 1 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\_ViewImports.cshtml"
using SpiceApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\_ViewImports.cshtml"
using SpiceApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f71dfced6b00e05b11e8523b66034ce5cfe65032", @"/Areas/Customer/Views/Order/OrderPickup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"936c661e67db1146200721b337eb797ea8506c14", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Order_OrderPickup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SpiceApp.Models.ViewModels.OrderListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn border", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn btn-light", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn btn-info active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-group float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::SpiceApp.TagHelpers.PageLinkTagHelper __SpiceApp_TagHelpers_PageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
  
    ViewData["Title"] = "Order History";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f71dfced6b00e05b11e8523b66034ce5cfe650325343", async() => {
                WriteLiteral(@"
        <br />
        <h2 class=""text-info"">Order Ready for Pickup :</h2>
        <div class=""border backgroundWhite"">
            <div class=""container border border-secondary"" style=""height:60px;"">
                <div class=""row container"">
                    <div class=""col-11"">
                        <div class=""row"" style=""padding-top:10px;"">
                            <div class=""col-4"">
                                ");
#nullable restore
#line 16 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control", @placeholder = "Name..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-4\">\r\n                                ");
#nullable restore
#line 19 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.Editor("searchPhone", new { htmlAttributes = new { @class = "form-control", @placeholder = "Phone..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-4\">\r\n                                ");
#nullable restore
#line 22 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.Editor("searchEmail", new { htmlAttributes = new { @class = "form-control", @placeholder = "Email..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                    <div class=""col-1"">
                        <div class=""row"" style=""padding-top:10px;"">
                            <button type=""submit"" name=""submit"" value=""search"" class=""btn btn-info form-control"">
                                <i class=""fas fa-search""></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <div>
");
#nullable restore
#line 38 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                 if (Model.Orders.Count() > 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <table class=\"table table-striped border\">\r\n                        <tr class=\"table-secondary\">\r\n                            <th>\r\n                                ");
#nullable restore
#line 43 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n\r\n                            <th>\r\n                                ");
#nullable restore
#line 47 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.PickupName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 50 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.ApplicationUser.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 53 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.PickupTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 56 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                           Write(Html.DisplayNameFor(m => m.Orders[0].OrderHeader.OrderTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                Total Items\r\n                            </th>\r\n                            <th></th>\r\n                        </tr>\r\n");
#nullable restore
#line 63 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                         foreach (var item in Model.Orders)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 67 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                               Write(Html.DisplayFor(m => item.OrderHeader.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 71 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                               Write(Html.DisplayFor(m => item.OrderHeader.PickupName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 74 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                               Write(Html.DisplayFor(m => item.OrderHeader.ApplicationUser.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 77 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                               Write(Html.DisplayFor(m => item.OrderHeader.PickupTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 80 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                               Write(Html.DisplayFor(m => item.OrderHeader.OrderTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 83 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                               Write(Html.DisplayFor(m => item.OrderDetails.Count));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <button type=\"button\" class=\"btn btn-success anchorDetail\" data-id=\"");
#nullable restore
#line 86 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                                                                                                   Write(item.OrderHeader.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" data-toggle=""modal"">
                                        <i class=""far fa-list-alt""></i>
                                        Details
                                    </button>
                                </td>
                            </tr>
");
#nullable restore
#line 92 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </table>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f71dfced6b00e05b11e8523b66034ce5cfe6503214515", async() => {
                    WriteLiteral("\r\n\r\n                    ");
                }
                );
                __SpiceApp_TagHelpers_PageLinkTagHelper = CreateTagHelper<global::SpiceApp.TagHelpers.PageLinkTagHelper>();
                __tagHelperExecutionContext.Add(__SpiceApp_TagHelpers_PageLinkTagHelper);
#nullable restore
#line 94 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
__SpiceApp_TagHelpers_PageLinkTagHelper.PageModel = Model.PagingInfo;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __SpiceApp_TagHelpers_PageLinkTagHelper.PageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 94 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
__SpiceApp_TagHelpers_PageLinkTagHelper.PageClassesEnabled = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __SpiceApp_TagHelpers_PageLinkTagHelper.PageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __SpiceApp_TagHelpers_PageLinkTagHelper.PageClass = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __SpiceApp_TagHelpers_PageLinkTagHelper.PageClassNormal = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __SpiceApp_TagHelpers_PageLinkTagHelper.PageClassSelected = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <br />\r\n");
#nullable restore
#line 98 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>No Orders exists...</p>\r\n");
#nullable restore
#line 102 "C:\Users\user\source\repos\SpiceApp\SpiceApp\Areas\Customer\Views\Order\OrderPickup.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog-centered modal-dialog"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header bg-success text-light"">
                        <div class=""col-10 offset-1"">
                            <center>
                                <h5 class=""modal-title"">
                                    Order Details
                                </h5>
                            </center>
                        </div>
                        <div class=""col-1"">
                            <button type=""button"" class=""float-right btn-outline-secondary close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>
                    </div>
                    <div class=""modal-body justify-content-center""");
            WriteLiteral(" id=\"myModalContent\">\r\n\r\n                    </div>\r\n                    \r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var PostBackUrl = '/Customer/Order/GetOrderDetails';

        $(function () {
            $("".anchorDetail"").click(function () {

                var $buttonClicked = $(this);
                var id = $buttonClicked.attr('data-id');
                $.ajax({
                    type: ""GET"",
                    url: PostBackUrl,
                    contentType: ""application/json; charset=utf-8"",
                    data: { ""Id"": id },
                    cache: false,
                    datatyype: ""json"",
                    success: function (data) {
                        $('#myModalContent').html(data);
                        $('#myModal').modal('show');
                    },
                    error: function () {
                        alert(""Content load failed"");
                    }
                });

            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SpiceApp.Models.ViewModels.OrderListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
