#pragma checksum "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "832368392a431be30856781f8d560cc85d609697"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
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
#line 1 "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\_ViewImports.cshtml"
using MikroButik.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\_ViewImports.cshtml"
using MikroButik.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\_ViewImports.cshtml"
using Miktobutik.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\_ViewImports.cshtml"
using Miktobutik.Models.EntityModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\_ViewImports.cshtml"
using Miktobutik.Models.InputModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hp\source\repos\mikroButik2\Presentations\MikroButik.Site\Views\_ViewImports.cshtml"
using Miktobutik.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"832368392a431be30856781f8d560cc85d609697", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a469067d6e62df4d7dc964f6e9600d4a6ffa3e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("mc-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mc-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"  <!-- Breadcrumb Section Start -->
<div class=""section"">

    <!-- Breadcrumb Area Start -->
    <div class=""breadcrumb-area bg-light"">
        <div class=""container-fluid"">
            <div class=""breadcrumb-content text-center"">
                <h1 class=""title"">Login | Register</h1>
                <ul>
                    <li>
                        <a href=""index.html"">Home </a>
                    </li>
                    <li class=""active""> Login | Register</li>
                </ul>
            </div>
        </div>
    </div>
    <!-- Breadcrumb Area End -->

</div>
<!-- Breadcrumb Section End -->
<!-- Login | Register Section Start -->
<div class=""section section-margin"">
    <div class=""container"">

        <div class=""row mb-n10"">
            <div class=""col-lg-6 col-md-8 m-auto m-lg-0 pb-10"">
                <!-- Login Wrapper Start -->
                <div class=""login-wrapper"">

                    <!-- Login Title & Content Start -->
                    <div c");
            WriteLiteral(@"lass=""section-content text-center mb-5"">
                        <h2 class=""title mb-2"">Login</h2>
                        <p class=""desc-content"">Please login using account detail bellow.</p>
                    </div>
                    <!-- Login Title & Content End -->
                    <!-- Form Action Start -->
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832368392a431be30856781f8d560cc85d6096976865", async() => {
                WriteLiteral(@"

                        <!-- Input Email Start -->
                        <div class=""single-input-item mb-3"">
                            <input type=""email"" placeholder=""Email or Username"">
                        </div>
                        <!-- Input Email End -->
                        <!-- Input Password Start -->
                        <div class=""single-input-item mb-3"">
                            <input type=""password"" placeholder=""Enter your Password"">
                        </div>
                        <!-- Input Password End -->
                        <!-- Checkbox/Forget Password Start -->
                        <div class=""single-input-item mb-3"">
                            <div class=""login-reg-form-meta d-flex align-items-center justify-content-between"">
                                <div class=""remember-meta mb-3"">
                                    <div class=""custom-control custom-checkbox"">
                                        <input type=""checkbox"" cl");
                WriteLiteral(@"ass=""custom-control-input"" id=""rememberMe"">
                                        <label class=""custom-control-label"" for=""rememberMe"">Remember Me</label>
                                    </div>
                                </div>
                                <a href=""#"" class=""forget-pwd mb-3"">Forget Password?</a>
                            </div>
                        </div>
                        <!-- Checkbox/Forget Password End -->
                        <!-- Login Button Start -->
                        <div class=""single-input-item mb-3"">
                            <button class=""btn btn btn-dark btn-hover-primary rounded-0"">Login</button>
                        </div>
                        <!-- Login Button End -->
                        <!-- Lost Password & Creat New Account Start -->
                        <div class=""lost-password"">
                            <a href=""login-register.html"">Creat Account</a>
                        </div>
                     ");
                WriteLiteral("   <!-- Lost Password & Creat New Account End -->\r\n\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <!-- Form Action End -->

                </div>
                <!-- Login Wrapper End -->
            </div>
            <div class=""col-lg-6 col-md-8 m-auto m-lg-0 pb-10"">
                <!-- Register Wrapper Start -->
                <div class=""register-wrapper"">

                    <!-- Login Title & Content Start -->
                    <div class=""section-content text-center mb-5"">
                        <h2 class=""title mb-2"">Create Account</h2>
                        <p class=""desc-content"">Please Register using account detail bellow.</p>
                    </div>
                    <!-- Login Title & Content End -->
                    <!-- Form Action Start -->
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832368392a431be30856781f8d560cc85d60969711367", async() => {
                WriteLiteral(@"

                        <!-- Input First Name Start -->
                        <div class=""single-input-item mb-3"">
                            <input type=""text"" placeholder=""First Name"">
                        </div>
                        <!-- Input First Name End -->
                        <!-- Input Last Name Start -->
                        <div class=""single-input-item mb-3"">
                            <input type=""text"" placeholder=""Last Name"">
                        </div>
                        <!-- Input Last Name End -->
                        <!-- Input Email Or Username Start -->
                        <div class=""single-input-item mb-3"">
                            <input type=""email"" placeholder=""Email or Username"">
                        </div>
                        <!-- Input Email Or Username End -->
                        <!-- Input Password Start -->
                        <div class=""single-input-item mb-3"">
                            <input type=""pas");
                WriteLiteral(@"sword"" placeholder=""Enter your Password"">
                        </div>
                        <!-- Input Password End -->
                        <!-- Checkbox & Subscribe Label Start -->
                        <div class=""single-input-item mb-3"">
                            <div class=""login-reg-form-meta d-flex align-items-center justify-content-between"">
                                <div class=""remember-meta mb-3"">
                                    <div class=""custom-control custom-checkbox"">
                                        <input type=""checkbox"" class=""custom-control-input"" id=""rememberMe-2"">
                                        <label class=""custom-control-label"" for=""rememberMe-2"">Subscribe Our Newsletter</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Checkbox & Subscribe Label End -->
                        <!-- Register Button Sta");
                WriteLiteral(@"rt -->
                        <div class=""single-input-item mb-3"">
                            <button class=""btn btn btn-dark btn-hover-primary rounded-0"">Register</button>
                        </div>
                        <!-- Register Button End -->

                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <!-- Form Action End -->

                </div>
                <!-- Register Wrapper End -->
            </div>
        </div>

    </div>
</div>
<!-- Login | Register Section End -->
<!-- Footer Section Start -->
<footer class=""section footer-section"">
    <!-- Footer Top Start -->
    <div class=""footer-top section-padding"">
        <div class=""container"">
            <div class=""row mb-n10"">
                <div class=""col-12 col-sm-6 col-lg-4 col-xl-4 mb-10"" data-aos=""fade-up"" data-aos-delay=""200"">
                    <div class=""single-footer-widget"">
                        <h2 class=""widget-title"">Contact Us</h2>
                        <p class=""desc-content"">Lorem ipsum dolor sit amet, consectetur adipisicing sed do eiusmod tempor incididun</p>
                        <!-- Contact Address Start -->
                        <ul class=""widget-address"">
                            <li><span>Address: </span> 123 Main Street, Anytown, CA 12345 - USA.</li>
    ");
            WriteLiteral(@"                        <li><span>Call to: </span> <a href=""#""> (012) 800 456 789-987</a></li>
                            <li><span>Mail to: </span> <a href=""#""> yourmail@example.com</a></li>
                        </ul>
                        <!-- Contact Address End -->
                        <!-- Soclial Link Start -->
                        <div class=""widget-social justify-content-start mt-4"">
                            <a title=""Facebook"" href=""#""><i class=""fa fa-facebook-f""></i></a>
                            <a title=""Twitter"" href=""#""><i class=""fa fa-twitter""></i></a>
                            <a title=""Linkedin"" href=""#""><i class=""fa fa-linkedin""></i></a>
                            <a title=""Youtube"" href=""#""><i class=""fa fa-youtube""></i></a>
                            <a title=""Vimeo"" href=""#""><i class=""fa fa-vimeo""></i></a>
                        </div>
                        <!-- Social Link End -->
                    </div>
                </div>
                <div");
            WriteLiteral(@" class=""col-12 col-sm-6 col-lg-2 col-xl-2 mb-10"" data-aos=""fade-up"" data-aos-delay=""300"">
                    <div class=""single-footer-widget"">
                        <h2 class=""widget-title"">Information</h2>
                        <ul class=""widget-list"">
                            <li><a href=""about.html"">About Us</a></li>
                            <li><a href=""about.html"">Delivery Information</a></li>
                            <li><a href=""about.html"">Privacy Policy</a></li>
                            <li><a href=""about.html"">Terms & Conditions</a></li>
                            <li><a href=""about.html"">Customer Service</a></li>
                            <li><a href=""about.html"">Return Policy</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-12 col-sm-6 col-lg-2 col-xl-2 mb-10"" data-aos=""fade-up"" data-aos-delay=""400"">
                    <div class=""single-footer-widget aos-init aos-animate"">
                ");
            WriteLiteral(@"        <h2 class=""widget-title"">My Account</h2>
                        <ul class=""widget-list"">
                            <li><a href=""account.html"">My Account</a></li>
                            <li><a href=""wishlist.html"">Wishlist</a></li>
                            <li><a href=""contact.html"">Newsletter</a></li>
                            <li><a href=""contact.html"">Help Center</a></li>
                            <li><a href=""contact.html"">Conditin</a></li>
                            <li><a href=""contact.html"">Term Of Use</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-12 col-sm-6 col-lg-4 col-xl-4 mb-10"" data-aos=""fade-up"" data-aos-delay=""500"">
                    <div class=""single-footer-widget"">
                        <h2 class=""widget-title"">Newsletter</h2>
                        <div class=""widget-body"">
                            <p class=""desc-content mb-0"">Get E-mail updates about our latest shop and ");
            WriteLiteral("special offers.</p>\r\n\r\n                            <!-- Newsletter Form Start -->\r\n                            <div class=\"newsletter-form-wrap pt-4\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832368392a431be30856781f8d560cc85d60969719865", async() => {
                WriteLiteral(@"
                                    <input type=""email"" id=""mc-email"" class=""form-control email-box mb-4"" placeholder=""Enter your email here.."" name=""EMAIL"">
                                    <button id=""mc-submit"" class=""newsletter-btn btn btn-primary btn-hover-dark"" type=""submit"">Subscribe</button>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                <!-- mailchimp-alerts Start -->
                                <div class=""mailchimp-alerts text-centre"">
                                    <div class=""mailchimp-submitting""></div><!-- mailchimp-submitting end -->
                                    <div class=""mailchimp-success text-success""></div><!-- mailchimp-success end -->
                                    <div class=""mailchimp-error text-danger""></div><!-- mailchimp-error end -->
                                </div>
                                <!-- mailchimp-alerts end -->
                            </div>
                            <!-- Newsletter Form End -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Footer Top End -->
    <!-- Footer Bottom Start -->
    <div class=""footer-bottom"">
        <div class=""container"">
            <div class=""row align-items-center"">
                <div class=""c");
            WriteLiteral(@"ol-12 text-center"">
                    <div class=""copyright-content"">
                        <p class=""mb-0"">Copyright © 2021 <a href=""https://hasthemes.com/"">HasThemes.</a> All Rights Reserved.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Footer Bottom End -->
</footer>
<!-- Footer Section End -->

");
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
