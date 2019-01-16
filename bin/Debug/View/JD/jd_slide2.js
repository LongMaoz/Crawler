var JDJRValidate = function (a, b) {
    this.params = a;
    this.callback = b;
    this.init()
};
JDJRValidate.prototype = {
    init: function () {
        this.lang = void 0 == this.params ? null : this.params.lang;
        this.slideTimer = null;
        this.mousePos = [];
        this.clickProductData = [];
        this.disX = 0;
        this.passValidate = !1;
        this.validateID = null;
        this.isDraging = !1;
        this.warp = this.getByID(this.params.id);
        this.clickResult = !1;
        this.i18nParams = this.i18n(this.lang);
        this.initHtml();
        this.getInstance()
    },
    i18n: function (a) {
        var b = {
            zh_CN: {
                "default-placeholder": "\u5411\u53f3\u6ed1\u52a8\u5b8c\u6210\u62fc\u56fe",
                "default-title": "\u5b8c\u6210\u62fc\u56fe\u9a8c\u8bc1",
                "default-refresh": "\u6362\u4e00\u5f20",
                "default-click": "\u70b9\u51fb\u5b8c\u6210\u9a8c\u8bc1",
                "default-slide-success": "\u62fc\u63a5\u6210\u529f",
                "default-suspend-success": "\u9a8c\u8bc1\u6210\u529f",
                "default-action-block": "\u64cd\u4f5c\u8fc7\u4e8e\u9891\u7e41",
                "default-slide-fail": "\u6ca1\u6709\u5bf9\u9f50\uff0c\u8bf7\u518d\u6765\u4e00\u6b21"
            },
            en_US: {
                "default-placeholder": "Swipe to complete puzzle",
                "default-title": "Complete the image",
                "default-refresh": "Refresh",
                "default-click": "Confirm registration",
                "default-slide-success": "Verification complete",
                "default-suspend-success": "Verification complete",
                "default-action-block": "You have performed this action too many times.",
                "default-slide-fail": "Incorrect. Please try again."
            },
            ru_RU: {
                "default-placeholder": "\u041f\u0440\u043e\u0432\u0435\u0434\u0438\u0442\u0435 \u0432\u043f\u0440\u0430\u0432\u043e",
                "default-title": "\u0417\u0430\u0432\u0435\u0440\u0448\u0438\u0442\u0435 \u043f\u0430\u0437\u043b",
                "default-refresh": "\u041e\u0431\u043d\u043e\u0432\u0438\u0442\u044c",
                "default-click": "\u041f\u043e\u0434\u0442\u0432\u0435\u0440\u0436\u0434\u0435\u043d\u0438\u0435 \u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0430\u0446\u0438\u0438",
                "default-slide-success": "\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0430 \u0443\u0441\u043f\u0435\u0448\u043d\u043e",
                "default-suspend-success": "\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0430 \u0443\u0441\u043f\u0435\u0448\u043d\u043e",
                "default-action-block": "\u041f\u0440\u0435\u0432\u044b\u0448\u0435\u043d\u043e \u0434\u043e\u043f\u0443\u0441\u0442\u0438\u043c\u043e\u0435 \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u043f\u043e\u043f\u044b\u0442\u043e\u043a.",
                "default-slide-fail": "\u041e\u0448\u0438\u0431\u043a\u0430. \u041f\u043e\u043f\u0440\u043e\u0431\u0443\u0439\u0442\u0435 \u0435\u0449\u0435 \u0440\u0430\u0437."
            },
            es_ES: {
                "default-placeholder": "completar la pieza",
                "default-title": "Completar la imagen",
                "default-refresh": "Actualizar",
                "default-click": "Haga clic para la verificaci\u00f3n",
                "default-slide-success": "Verificado con \u00e9xito",
                "default-suspend-success": "Verificado con \u00e9xito",
                "default-action-block": "Has realizado esta acci\u00f3n muchas veces.",
                "default-slide-fail": "Incorrecto. Int\u00e9ntalo de nuevo."
            },
            th_TH: {
                "default-placeholder": "\u0e40\u0e25\u0e37\u0e48\u0e2d\u0e19\u0e0a\u0e34\u0e49\u0e19\u0e2a\u0e48\u0e27\u0e19\u0e08\u0e34\u0e4a\u0e01\u0e0b\u0e2d\u0e27\u0e4c\u0e43\u0e2b\u0e49\u0e40\u0e02\u0e49\u0e32\u0e17\u0e35\u0e48",
                "default-title": "\u0e40\u0e25\u0e48\u0e21\u0e40\u0e01\u0e21\u0e40\u0e1e\u0e37\u0e48\u0e2d\u0e25\u0e07\u0e17\u0e30\u0e40\u0e1a\u0e35\u0e22\u0e19",
                "default-refresh": "\u0e40\u0e1b\u0e25\u0e35\u0e48\u0e22\u0e19\u0e23\u0e39\u0e1b",
                "default-click": "\u0e16\u0e31\u0e14\u0e44\u0e1b",
                "default-slide-success": "\u0e22\u0e34\u0e19\u0e14\u0e35\u0e14\u0e49\u0e27\u0e22!",
                "default-suspend-success": "\u0e22\u0e34\u0e19\u0e14\u0e35\u0e14\u0e49\u0e27\u0e22!",
                "default-action-block": "You have performed this action too many times.",
                "default-slide-fail": "Incorrect. Please try again."
            },
            en_TH: {
                "default-placeholder": "Swipe to complete puzzle",
                "default-title": "Complete the puzzle",
                "default-refresh": "Change",
                "default-click": "Next",
                "default-slide-success": "Congratulations!",
                "default-suspend-success": "Congratulations!",
                "default-action-block": "You have performed this action too many times.",
                "default-slide-fail": "Incorrect. Please try again."
            }
        };
        return b.hasOwnProperty(a) ? b[a] : b.zh_CN
    },
    getByID: function (a) {
        return document.getElementById(a)
    },
    initGetElementsByName: function (a) {
        a.getElementsByClassName = function (b) {
            for (var c = (a || document).getElementsByTagName("*"), e = [], f = 0; f < c.length; f++)
                for (var d = c[f], g = d.className.split(" "), h = 0; h < g.length; h++)
                    if (g[h] == b) {
                        e.push(d);
                        break
                    }
            return e
        }
    },
    initHtml: function () {
        var a = this,
            b = "JDJRV-" + (this.params.product ? this.params.product : "embed"),
            c = this.params.width ? this.params.width : "100%",
            e = this.params.placeholder ? this.params.placeholder : a.i18nParams["default-placeholder"],
            f = this.params.refreshRight ? this.params.refreshRight : "0px",
            d = "";
        if ("bind" == this.params.product || "popup" == this.params.product || "click-popup" == this.params.product) d += '<div id="JDJRV-wrap-' + this.params.id + '" class="JDJRV-pop-wrap JDValidate-wrap"><div class="JDJRV-pop-bg"></div><div class="JDJRV-pop-content"><a class="JDJRV-close"></a>', f = "15px";
        "click-suspend" == this.params.product && (d += '<div id="JDJRV-wrap-' + this.params.id + '" class="JDJRV-click-suspend-wrap JDValidate-wrap"><a class="JDJRV-close"></a><a class="JDJRV-arrow"></a>', f = "15px");
        if ("click-bind-suspend" == this.params.product) {
            f = this.clickWarp.getBoundingClientRect().left + document.documentElement.scrollLeft;
            var g = this.clickWarp.getBoundingClientRect().top + document.documentElement.scrollTop;
            c = 0 < c.indexOf("%") ? .01 * c.replace("%", "") * this.clickWarp.offsetWidth + "px" : c;
            0 < c.indexOf("px") && (g -= 140 / (360 / (c.replace("px", "") - 24)) + 120);
            d += '<div class="JDJRV-suspend-warp JDJRV-bind-suspend-wrap" id="JDJRV-wrap-' + this.params.id + '" style="width: ' + c + ";top:" + ("undefined" != typeof this.params.top ? this.params.top : g + "px") + ";left:" + f + "px;height:" + (g + 112) + 'px"><div class="JDJRV-suspend-slide"><div style="" class=" JDValidate-wrap"><a class="JDJRV-close"></a>' + ("undefined" != typeof this.params.top ? "" : '<a class="JDJRV-arrow"></a>');
            f = "15px"
        }
        if ("click" != this.params.product && "click-bind" != this.params.product && "suspend" != this.params.product && "bind-suspend" != this.params.product) {
            g = c;
            if ("bind" == this.params.product || "popup" == this.params.product || "click-popup" == this.params.product || "click-suspend" == this.params.product || "click-bind-suspend" == this.params.product) g = "auto";
            var h = -1 < navigator.userAgent.indexOf("compatible") && -1 < navigator.userAgent.indexOf("MSIE");
            d += '<div class="JDJRV-slide" style="width: ' + g + '"><div class="JDJRV-img-panel ' + b + '"><div class="JDJRV-refresh" style="margin-right: ' + f + '"><div class="JDJRV-lable-refresh">' + a.i18nParams["default-title"] + '</div><div class="JDJRV-img-refresh"><span>' + a.i18nParams["default-refresh"] + '</span><div></div></div></div><div class="JDJRV-img-wrap"><div class="JDJRV-bigimg"><img src="" ' + (h ? 'height="0px"' : "") + '></div><div class="JDJRV-smallimg"><img src="" ' + (h ? 'height="0px"' : "") + '></div></div></div><div class="JDJRV-slide-bg"><div class="JDJRV-slide-inner JDJRV-slide-text"><div class="JDJRV-slide-left"></div><div class="JDJRV-slide-center">' + e + '</div><div class="JDJRV-slide-right"></div></div><div class="JDJRV-slide-inner JDJRV-slide-bar"><div class="JDJRV-slide-bar-left"></div><div class="JDJRV-slide-bar-center"></div><div class="JDJRV-slide-bar-right"></div></div><div class="JDJRV-slide-inner JDJRV-slide-btn">\x3c!--<span class="JDJRV-slide-icon"></span>--\x3e</div></div></div>'
        }
        if ("bind" == this.params.product || "popup" == this.params.product || "click-popup" == this.params.product) {
            d += "</div></div>";
            b = document.createElement("div");
            b.innerHTML = d;
            for (d = document.createDocumentFragment(); b.firstChild;) d.appendChild(b.firstChild);
            (b = this.getByID("JDJRV-wrap-" + this.params.id)) && document.body.removeChild(b);
            document.body.appendChild(d);
            this.warp = this.getByID("JDJRV-wrap-" + this.params.id);
            this.warp.getElementsByClassName || this.initGetElementsByName(this.warp);
            this.closeBtn = this.warp.getElementsByClassName("JDJRV-close")[0];
            this.popContent = this.warp.getElementsByClassName("JDJRV-pop-content")[0];
            "popup" == this.params.product && (this.clickWarp = this.getByID(this.params.id), c = '<div class="JDJRV-click-warp" style="width: ' + c + '"><img class="JDJRV-click-img" src="//ivs.jd.com/slide/i/wait.gif"><div class="JDJRV-click-text">' + a.i18nParams["default-click"] + "</div></div>", this.clickWarp.innerHTML = c, this.clickWarp.getElementsByClassName || this.initGetElementsByName(this.clickWarp), this.clickContent = this.clickWarp.getElementsByClassName("JDJRV-click-warp")[0], this.clickImg = this.clickWarp.getElementsByClassName("JDJRV-click-img")[0], this.clickText = this.clickWarp.getElementsByClassName("JDJRV-click-text")[0])
        } else if ("click" == this.params.product) this.clickWarp = this.getByID(this.params.id), c = '<div class="JDJRV-click-warp" style="width: ' + c + '"><img class="JDJRV-click-img" src="//ivs.jd.com/slide/i/wait.gif"><div class="JDJRV-click-text">' + a.i18nParams["default-click"] + "</div></div>", this.clickWarp.innerHTML = c, this.clickWarp.getElementsByClassName || this.initGetElementsByName(this.clickWarp), this.clickContent = this.clickWarp.getElementsByClassName("JDJRV-click-warp")[0], this.clickImg = this.clickWarp.getElementsByClassName("JDJRV-click-img")[0], this.clickText = this.clickWarp.getElementsByClassName("JDJRV-click-text")[0];
        else if ("click-bind" == this.params.product || "bind-suspend" == this.params.product) this.clickWarp = this.getByID(this.params.id), this.clickWarp.getElementsByClassName || this.initGetElementsByName(this.clickWarp);
        else if ("suspend" == this.params.product) this.warp = this.getByID(this.params.id), this.warp.getElementsByClassName || this.initGetElementsByName(this.warp), d = this.params.height || "40px", c = '<div class="JDJRV-suspend-warp" style="width: ' + c + '"><div class="JDJRV-suspend-slide"></div><div class="JDJRV-suspend-click" style=";height:' + d + ";line-height:" + d + '">' + a.i18nParams["default-click"] + "</div></div>", this.warp.innerHTML = c, this.clickWarp = this.warp.getElementsByClassName("JDJRV-suspend-click")[0], this.clickContent = this.warp.getElementsByClassName("JDJRV-suspend-click")[0], this.clickText = this.warp.getElementsByClassName("JDJRV-suspend-click")[0], this.suspendSlideWarp = this.warp.getElementsByClassName("JDJRV-suspend-slide")[0], this.suspendSlideWarp.style.bottom = this.clickWarp.offsetHeight + 6 + "px";
        else if ("click-suspend" == this.params.product) this.suspendSlideWarp.innerHTML = d + "</div></div>", this.closeBtn = this.warp.getElementsByClassName("JDJRV-close")[0], this.suspendSlideWarp.style.display = "block";
        else if ("click-bind-suspend" == this.params.product) {
            d += "</div></div></div></div>";
            b = document.createElement("div");
            b.innerHTML = d;
            for (d = document.createDocumentFragment(); b.firstChild;) d.appendChild(b.firstChild);
            (b = this.getByID("JDJRV-wrap-" + this.params.id)) && document.body.removeChild(b);
            document.body.appendChild(d);
            this.warp = this.getByID("JDJRV-wrap-" + this.params.id);
            this.warp.getElementsByClassName || this.initGetElementsByName(this.warp);
            this.suspendSlideWarp = this.warp.getElementsByClassName("JDJRV-suspend-slide")[0];
            this.closeBtn = this.warp.getElementsByClassName("JDJRV-close")[0]
        } else this.warp.innerHTML = d;
        "click" != this.params.product && "click-bind" != this.params.product && "suspend" != this.params.product && "bind-suspend" != this.params.product ? "click-popup" == this.params.product || "click-suspend" == this.params.product || "click-bind-suspend" == this.params.product ? a.initSlideWrap() : setTimeout(function () {
            a.initSlideWrap()
        }, 50) : setTimeout(function () {
            a.initClickWrap()
        }, 50)
    },
    initSlideWrap: function () {
        this.warp.getElementsByClassName || this.initGetElementsByName(this.warp);
        this.slideWrap = this.warp.getElementsByClassName("JDJRV-slide")[0];
        this.imgRatio = (this.width = this.slideWrap.offsetWidth) ? 360 / this.slideWrap.offsetWidth : 1;
        this.slideBar = this.warp.getElementsByClassName("JDJRV-slide-bg")[0];
        this.slideBtn = this.warp.getElementsByClassName("JDJRV-slide-btn")[0];
        this.slideGreenBar = this.warp.getElementsByClassName("JDJRV-slide-bar")[0];
        this.slideGreenBarCenter = this.warp.getElementsByClassName("JDJRV-slide-bar-center")[0];
        this.slideSmallImg = this.warp.getElementsByClassName("JDJRV-smallimg")[0];
        this.slideBigImg = this.warp.getElementsByClassName("JDJRV-bigimg")[0];
        this.slideImgWrap = this.warp.getElementsByClassName("JDJRV-img-panel")[0];
        this.slideCenter = this.warp.getElementsByClassName("JDJRV-slide-center")[0];
        this.slideImgWrap.getElementsByClassName || this.initGetElementsByName(this.slideImgWrap);
        this.refreshBtn = this.slideImgWrap.getElementsByClassName("JDJRV-img-refresh")[0];
        this.slideText = this.warp.getElementsByClassName("JDJRV-slide-text")[0];
        this.slideBigImg.style.height = 140 / (360 / this.slideWrap.offsetWidth) + "px";
        this.getValidateImage();
        this.bindEvent()
    },
    initClickWrap: function () {
        function a(a) {
            if ("click" == c.params.product || "click-bind" == c.params.product || "suspend" == c.params.product || "bind-suspend" == c.params.product) a = a || event, a.touches && (a = a.touches[0]), c.clickProductData.push([a.clientX.toFixed(0), a.clientY.toFixed(0), (new Date).getTime()])
        }

        function b() {
            c.clickResult || ("click-popup" == c.params.product ? (c.warp.style.display = "block", c.resetSize()) : "click-suspend" == c.params.product ? (c.suspendSlideWarp.style.display = "block", c.resetSize()) : "click-bind-suspend" == c.params.product ? (c.warp.style.display = "block", c.resetSize()) : c.submit())
        }
        var c = this;
        c.getValidateImage();
        0 == c.params.eventListener || "false" == c.params.eventListener ? c.verify = b : (c.clickWarp.onclick = b, c.params.formId && (document.getElementById(c.params.formId).onsubmit = function () {
            b();
            return !1
        }));
        document.onmousemove = a;
        document.ontouchmove = a
    },
    bindEvent: function () {
        function a(a) {
            function c(a) {
                a = a || event;
                document.all ? (window.event.returnValue = !1, window.event.cancelBubble = !0) : (a.preventDefault(), a.stopPropagation(), a.returnValue = !1);
                a.touches && (a = a.touches[0]);
                var c = a.clientX - b.disX + 40,
                    d = a.clientX - b.disX,
                    e = a.clientX - b.disX;
                0 > e ? e = 0 : e > b.width - 50 / b.imgRatio && (e = b.width - 50 / b.imgRatio);
                0 > d ? d = 0 : d > b.width - 40 && (d = b.width - 40);
                44 > c ? c = 44 : c > b.width && (c = b.width);
                b.mousePos.push([a.clientX.toFixed(0), a.clientY.toFixed(0), (new Date).getTime()]);
                b.slideBtn.style.left = d + "px";
                b.slideSmallImg.style.left = e + "px";
                b.slideGreenBar.style.width = c + "px";
                return !1
            }

            function e(a) {
                a = a || event;
                a.changedTouches && (a = a.changedTouches[0]);
                b.isDraging = !1;
                b.mousePos.push([a.clientX.toFixed(0), a.clientY.toFixed(0), (new Date).getTime()]);
                document.onmousemove = null;
                document.ontouchmove = null;
                document.onmouseup = null;
                document.ontouchend = null;
                3 >= b.mousePos.length ? (b.slideGreenBar.style.display = "none", b.slideText.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-text"), b.slideText.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-text")) : b.submit()
            }
            b.passValidate || (b.isDraging = !0, a = a || event, document.all ? (window.event.returnValue = !1, window.event.cancelBubble = !0) : (a.preventDefault(), a.stopPropagation(), a.returnValue = !1), a.touches && (a = a.touches[0]), b.disX = a.clientX, b.slideGreenBar.style.display = "block", b.mousePos = [], b.mousePos.push([b.getLeft(b.slideBtn).toFixed(0), b.getTop(b.slideBtn).toFixed(0), (new Date).getTime()]), b.mousePos.push([a.clientX.toFixed(0), a.clientY.toFixed(0), (new Date).getTime()]), document.onmousemove = c, document.ontouchmove = c, document.onmouseup = e, document.ontouchend = e)
        }
        var b = this;
        "click-popup" == b.params.product && (b.closeBtn.onclick = function () {
            b.warp.style.display = "none"
        });
        "click-suspend" == b.params.product && (b.closeBtn.onclick = function () {
            b.suspendSlideWarp.style.display = "none"
        });
        "click-bind-suspend" == b.params.product && (b.closeBtn.onclick = function () {
            b.warp.style.display = "none"
        });
        "popup" == b.params.product && (b.clickWarp.onclick = function () {
            b.warp.style.display = "block";
            b.resetSize()
        }, b.closeBtn.onclick = function () {
            b.warp.style.display = "none"
        });
        "bind" == b.params.product && (0 == b.params.eventListener || "false" == b.params.eventListener ? b.verify = function () {
            b.warp.style.display = "block";
            b.resetSize()
        } : document.getElementById(b.params.id).onclick = function () {
            b.warp.style.display = "block";
            b.resetSize()
        }, b.closeBtn.onclick = function () {
            b.warp.style.display = "none"
        });
        b.slideBtn.onmousedown = a;
        b.slideBtn.ontouchstart = a;
        if ("float" == this.params.product) {
            var c = !1,
                e = !1;
            this.slideImgWrap.onmouseover = function () {
                c = !0
            };
            this.slideImgWrap.onmouseout = function () {
                c = !1;
                b.slideTimer = setTimeout(function () {
                    c || e || (b.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float"), b.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float "))
                }, 300)
            };
            this.slideBar.onmouseover = function () {
                e = !0;
                b.passValidate || b.isDraging || (clearTimeout(b.slideTimer), b.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float JDJRV-float-hover"), b.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float JDJRV-float-hover"))
            };
            this.slideBar.onmouseout = function () {
                e = !1;
                b.isDraging || (b.slideTimer = setTimeout(function () {
                    c || (b.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float"), b.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float "))
                }, 300))
            }
        }
        this.refreshBtn.onclick = function () {
            b.passValidate || b.isDraging || (b.getValidateImage(), b.params.refreshCallback && b.callback({
                getSuccess: function () {
                    return "2"
                },
                getMessage: function () {
                    return "refresh"
                },
                getValidate: function () {
                    return ""
                }
            }))
        };
        window.onresize = function () {
            b.resetSize()
        }
    },
    getInstance: function () {
        this.params.getInstance && this.params.getInstance(this)
    },
    resetSize: function () {
        if (this.y) {
            this.width = this.slideWrap.offsetWidth;
            var a = this.imgRatio;
            this.imgRatio = this.slideWrap.offsetWidth ? 360 / this.slideWrap.offsetWidth : 0;
            this.slideSmallImg.style.top = this.y / this.imgRatio + "px";
            this.slideSmallImg.style.width = 50 / this.imgRatio + "px";
            this.slideBigImg.style.height = 140 / (360 / this.slideWrap.offsetWidth) + "px";
            this.slideSmallImg.style.left = this.slideSmallImg.offsetLeft * a / this.imgRatio + "px"
        }
        if ("bind" == this.params.product || "popup" == this.params.product || "click-popup" == this.params.product) this.popContent.style.marginLeft = 360 > this.popContent.offsetWidth ? -.45 * document.body.clientWidth + "px" : this.popContent.offsetWidth / 2 * -1 + "px";
        if ("click-bind-suspend" == this.params.product && this.slideWrap) {
            a = this.clickWarp.getBoundingClientRect().left + document.documentElement.scrollLeft;
            var b = this.clickWarp.getBoundingClientRect().top + document.documentElement.scrollTop;
            b -= 140 / (360 / this.slideWrap.offsetWidth) + 120;
            this.warp.style.top = "undefined" != typeof this.params.top ? this.params.top : b + "px";
            this.warp.style.left = a + "px"
        }
    },
    resetValidate: function () {
        var a = this;
        setTimeout(function () {
            a.slideBtn.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-btn JRJRV-animate-el");
            a.slideBtn.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-btn JRJRV-animate-el");
            a.slideGreenBar.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-bar JRJRV-animate-el");
            a.slideGreenBar.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-bar JRJRV-animate-el");
            a.slideWrap.setAttribute("class", "JDJRV-slide");
            a.slideWrap.setAttribute("className", "JDJRV-slide");
            a.slideBtn.style.left = "0px";
            a.slideGreenBar.style.width = "0";
            a.slideText.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-text");
            a.slideText.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-text");
            setTimeout(function () {
                a.slideBtn.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-btn");
                a.slideBtn.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-btn");
                a.slideGreenBar.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-bar");
                a.slideGreenBar.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-bar")
            }, 400)
        }, 600)
    },
    getValidateImage: function () {
        var a = this;
        a.jsonp("//iv.jd.com/slide/g.html", {
            appId: a.params.appId,
            scene: a.params.scene,
            product: a.params.product,
            e: a.getEid()
        }, "callback", function (b) {
            "click" != a.params.product && "click-bind" != a.params.product && "suspend" != a.params.product && "bind-suspend" != a.params.product && (a.slideBigImg.innerHTML = '<img src="' + a.getImgSrc(b.static_servers, b.bg) + '">', a.slideSmallImg.innerHTML = '<img src="' + a.getImgSrc(b.static_servers, b.patch) + '">', a.y = b.y, a.slideSmallImg.style.top = b.y / a.imgRatio + "px", a.slideSmallImg.style.width = 50 / a.imgRatio + "px", a.slideSmallImg.style.left = "0px");
            a.validateID = b.challenge;
            a.o = b.o;
            setTimeout(function () {
                a.resetSize()
            }, 1)
        })
    },
    submit: function () {
        var a = this;
        if ("click" == a.params.product || "click-bind" == a.params.product || "suspend" == a.params.product || "bind-suspend" == a.params.product) {
            var b = a.clickProductData;
            var c = b.length;
            300 < c && (b = a.clickProductData.slice(c - 300, c))
        } else b = a.mousePos;
        c = "";
        if (a.o) try {
            var e = a.getByID(a.o);
            e && (c = encodeURIComponent(e.value))
        } catch (f) {}

        //修改by:余观成 2018.12.6
        var obj_submit = {
            d: a.getCoordinate(b),
            c: a.validateID,
            w: a.width ? a.width.toFixed(0) : 0,
            appId: a.params.appId,
            scene: a.params.scene,
            product: a.params.product,
            e: a.getEid(),
            s: a.getSessionId(),
            o: c
        };
        console.log("Sumit obj:");
        console.log(obj_submit);
        a.ajax({
            url: "?action=submit&d=" + obj_submit.d + "&c=" + obj_submit.c + "&w=" + obj_submit.w + "&s=" + obj_submit.s + "&appid=" + obj_submit.appId + "&scene=&product=" + obj_submit.scene + "&e=" + obj_submit.product,
            success: function (d) {
                d = eval("(" + d + ")");
                console.log("Sumit success:");
                console.log(d);
                "click" == a.params.product || "click-bind" == a.params.product || "suspend" == a.params.product || "bind-suspend" == a.params.product ? 0 == b.success ? (a.params.product = "suspend" == a.params.product ? "click-suspend" : "bind-suspend" == a.params.product ? "click-bind-suspend" : "click-popup", a.initHtml(), a.warp.style.display = "block", a.resetSize()) : a.clickSuccess() : 0 == b.success ? (a.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-err"), a.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-err"), setTimeout(function () {
                    a.getValidateImage()
                }, 500), a.resetValidate()) : (a.passValidate = !0, a.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-succ"), a.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-succ"), a.slideGreenBar.style.width = "100%", a.slideGreenBarCenter.innerHTML = a.params.successMess ? a.params.successMess : a.i18nParams["default-slide-success"], a.refreshBtn.style.display = "none", "float" == a.params.product && (a.slideTimer = setTimeout(function () {
                    a.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float");
                    a.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float")
                }, 300)), "bind" != a.params.product && "popup" != a.params.product && "click-popup" != a.params.product && "click-bind-suspend" != a.params.product || setTimeout(function () {
                    a.warp.style.display = "none"
                }, 800), "popup" != a.params.product && "click-popup" != a.params.product && "click-suspend" != a.params.product || a.clickSuccess());
                a.submitCallback(d)
            },
            fail: function (state) {
                console.log("Sumit fail:");
                console.log(d);
            }
        });
        return;
        //修改by:余观成 2018.12.6 END
        a.jsonp("//iv.jd.com/slide/s.html", {
            d: a.getCoordinate(b),
            c: a.validateID,
            w: a.width ? a.width.toFixed(0) : 0,
            appId: a.params.appId,
            scene: a.params.scene,
            product: a.params.product,
            e: a.getEid(),
            s: a.getSessionId(),
            o: c
        }, "callback", function (b) {
            "click" == a.params.product || "click-bind" == a.params.product || "suspend" == a.params.product || "bind-suspend" == a.params.product ? 0 == b.success ? (a.params.product = "suspend" == a.params.product ? "click-suspend" : "bind-suspend" == a.params.product ? "click-bind-suspend" : "click-popup", a.initHtml(), a.warp.style.display = "block", a.resetSize()) : a.clickSuccess() : 0 == b.success ? (a.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-err"), a.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-err"), setTimeout(function () {
                a.getValidateImage()
            }, 500), a.resetValidate()) : (a.passValidate = !0, a.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-succ"), a.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-succ"), a.slideGreenBar.style.width = "100%", a.slideGreenBarCenter.innerHTML = a.params.successMess ? a.params.successMess : a.i18nParams["default-slide-success"], a.refreshBtn.style.display = "none", "float" == a.params.product && (a.slideTimer = setTimeout(function () {
                a.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float");
                a.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float")
            }, 300)), "bind" != a.params.product && "popup" != a.params.product && "click-popup" != a.params.product && "click-bind-suspend" != a.params.product || setTimeout(function () {
                a.warp.style.display = "none"
            }, 800), "popup" != a.params.product && "click-popup" != a.params.product && "click-suspend" != a.params.product || a.clickSuccess());
            a.submitCallback(b)
        }, function () {
            "click" == a.params.product || "click-bind" == a.params.product ? (a.params.product = "click-popup", a.initHtml(), a.warp.style.display = "block", setTimeout(function () {
                a.resetSize()
            }, 50)) : (a.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-err"), a.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-err"), setTimeout(function () {
                a.getValidateImage()
            }, 500), a.resetValidate())
        })
    },
    submitCallback: function (a) {
        var b = {
            getSuccess: function () {
                return a.success
            },
            getMessage: function () {
                return a.message
            },
            getValidate: function () {
                return ""
            }
        };
        0 == a.success ? this.params.failCallback && this.callback(b) : (b.getValidate = function () {
            return a.validate
        }, this.callback(b))
    },
    clickSuccess: function () {
        this.clickContent && ("suspend" == this.params.product ? (this.clickContent.setAttribute("class", "JDJRV-suspend-click JDJRV-suspend-click-success"), this.clickContent.setAttribute("className", "JDJRV-suspend-click JDJRV-suspend-click-success"), this.clickText.innerHTML = this.params.successMess ? this.params.successMess : this.i18nParams["default-suspend-success"]) : "click-suspend" == this.params.product ? (this.clickContent.setAttribute("class", "JDJRV-suspend-click JDJRV-suspend-click-success"), this.clickContent.setAttribute("className", "JDJRV-suspend-click JDJRV-suspend-click-success"), this.clickText.innerHTML = this.params.successMess ? this.params.successMess : this.i18nParams["default-suspend-success"], this.suspendSlideWarp.style.display = "none") : (this.clickContent.setAttribute("class", "JDJRV-click-warp JDJRV-click-success"), this.clickContent.setAttribute("className", "JDJRV-click-warp JDJRV-click-success"), this.clickImg.src = "//ivs.jd.com/slide/i/slide-succ.png", this.clickText.innerHTML = this.params.successMess ? this.params.successMess : this.i18nParams["default-suspend-success"]));
        this.clickResult = !0
    },
    getImgSrc: function (a, b) {
        return (0 < b.lastIndexOf(".png") || 0 < b.lastIndexOf(".jpg") || 0 < b.lastIndexOf(".webp") ? a : "data:image/png;base64,") + b
    },
    jsonp: function (a, b, c, e, f) {
        var d = "jsonp_" + Math.random();
        d = d.replace(".", "");
        window[d] = function (a) {
            clearTimeout(g);
            window[d] = null;
            l.removeChild(k);
            e(a)
        };
        var g = setTimeout(function () {
            window[d] = null;
            l.removeChild(k);
            f && f()
        }, 5E3);
        b[c] = d;
        c = [];
        for (var h in b) c.push(h + "=" + b[h]);
        a = a + "?" + c.join("&");
        var k = document.createElement("script");
        k.src = a;
        k.type = "text/javascript";
        var l = document.getElementsByTagName("head")[0];
        l.appendChild(k)
    },
    ajax: function (a) {
        a = a || {};
        a.type = (a.type || "GET").toUpperCase();
        a.dataType = a.dataType || "json";
        var b = this.formatParams(a.data),
            c = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");
        c.onreadystatechange = function () {
            if (4 == c.readyState) {
                var b = c.status;
                200 <= b && 300 > b ? a.success && a.success(c.responseText, c.responseXML) : a.fail && a.fail(b)
            }
        };
        "GET" == a.type ? (c.open("GET", a.url + "?" + b, !0), c.send(null)) : "POST" == a.type && (c.open("POST", a.url, !0), c.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"), c.send(b))
    },
    formatParams: function (a) {
        var b = [],
            c;
        for (c in a) b.push(encodeURIComponent(c) + "=" + encodeURIComponent(a[c]));
        b.push(("v=" + Math.random()).replace(".", ""));
        return b.join("&")
    },
    string10to64: function (a) {
        var b = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-~".split(""),
            c = b.length;
        a = +a;
        var e = [];
        do mod = a % c, a = (a - mod) / c, e.unshift(b[mod]); while (a);
        return e.join("")
    },
    prefixInteger: function (a, b) {
        return (Array(b).join(0) + a).slice(-b)
    },
    pretreatment: function (a, b, c) {
        var e = this.string10to64(Math.abs(a)),
            f = "";
        c || (f += 0 < a ? "1" : "0");
        return f += this.prefixInteger(e, b)
    },
    getCoordinate: function (a) {
        for (var b = [], c = 0; c < a.length; c++)
            if (0 == c) b.push(this.pretreatment(262143 > a[c][0] ? a[c][0] : 262143, 3, !0)), b.push(this.pretreatment(16777215 > a[c][1] ? a[c][1] : 16777215, 4, !0)), b.push(this.pretreatment(4398046511103 > a[c][2] ? a[c][2] : 4398046511103, 7, !0));
            else {
                var e = a[c][0] - a[c - 1][0],
                    f = a[c][1] - a[c - 1][1],
                    d = a[c][2] - a[c - 1][2];
                b.push(this.pretreatment(4095 > e ? e : 4095, 2, !1));
                b.push(this.pretreatment(4095 > f ? f : 4095, 2, !1));
                b.push(this.pretreatment(16777215 > d ? d : 16777215, 4, !0))
            }
        return b.join("")
    },
    getEid: function () {
        var a = "";
        try {
            a = getJdEid().eid
        } catch (b) {}
        try {
            "" == a && getJdEid(function (b, c, e) {
                a = b
            })
        } catch (b) {}
        return a
    },
    getSessionId: function () {
        var a = "";
        try {
            "undefined" != typeof _jdtdmap_sessionId && (a = _jdtdmap_sessionId)
        } catch (b) {
            console.error("sessionId err;")
        }
        return a
    },
    getLeft: function (a) {
        var b = a.offsetLeft;
        null != a.offsetParent && (b += this.getLeft(a.offsetParent));
        return b
    },
    getTop: function (a) {
        var b = a.offsetTop;
        null != a.offsetParent && (b += this.getTop(a.offsetParent));
        return b
    }
};