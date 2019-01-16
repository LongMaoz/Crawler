var JDJRValidate = function (a, b) {
    this.params = a;
    this.callback = b;
    this.ii()
};
JDJRValidate.prototype = {
    ii: function () {
        this.slideTimer = null;
        this.mousePos = [];
        this.clickProductData = [];
        this.disX = 0;
        this.passValidate = false;
        this.validateID = null;
        this.isDraging = false;
        this.warp = this.gi(this.params.id);
        this.clickResult = false;
        this.ih();
        this.it()
    },
    gi: function (a) {
        return document.getElementById(a)
    },
    ge: function (a) {
        a.getElementsByClassName = function (e) {
            var d = (a || document).getElementsByTagName("*");
            var f = new Array();
            for (var c = 0; c < d.length; c++) {
                var h = d[c];
                var g = h.className.split(" ");
                for (var b = 0; b < g.length; b++) {
                    if (g[b] == e) {
                        f.push(h);
                        break
                    }
                }
            }
            return f
        }
    },
    ih: function () {
        var j = this;
        var k = "JDJRV-" + (this.params.product ? this.params.product : "embed");
        var b = this.params.width ? this.params.width : "100%";
        var n = this.params.placeholder ? this.params.placeholder : "向右滑动完成拼图";
        var e = this.params.refreshRight ? this.params.refreshRight : "0px";
        var g = "";
        if (this.params.product == "bind" || this.params.product == "popup" || this.params.product == "click-popup") {
            g += '<div id="JDJRV-wrap-' + this.params.id + '" class="JDJRV-pop-wrap JDValidate-wrap"><div class="JDJRV-pop-bg"></div><div class="JDJRV-pop-content"><a class="JDJRV-close"></a>';
            e = "15px"
        }
        if (this.params.product == "click-suspend") {
            g += '<div id="JDJRV-wrap-' + this.params.id + '" class="JDJRV-click-suspend-wrap JDValidate-wrap"><a class="JDJRV-close"></a><a class="JDJRV-arrow"></a>';
            e = "15px"
        }
        if (this.params.product == "click-bind-suspend") {
            var m = this.clickWarp.getBoundingClientRect().left + document.documentElement.scrollLeft;
            var l = this.clickWarp.getBoundingClientRect().top + document.documentElement.scrollTop;
            b = b.indexOf("%") > 0 ? (b.replace("%", "") * 0.01 * this.clickWarp.offsetWidth + "px") : b;
            if (b.indexOf("px") > 0) {
                l -= 140 / (360 / (b.replace("px", "") - 24)) + 120
            }
            g += '<div class="JDJRV-suspend-warp JDJRV-bind-suspend-wrap" id="JDJRV-wrap-' + this.params.id + '" style="width: ' + b + ";top:" + l + "px;left:" + m + "px;height:" + (l + 112) + 'px"><div class="JDJRV-suspend-slide"><div style="" class=" JDValidate-wrap"><a class="JDJRV-close"></a><a class="JDJRV-arrow"></a>';
            e = "15px"
        }
        if (this.params.product != "click" && this.params.product != "click-bind" && this.params.product != "suspend" && this.params.product != "bind-suspend") {
            var a = b;
            if (this.params.product == "bind" || this.params.product == "popup" || this.params.product == "click-popup" || this.params.product == "click-suspend" || this.params.product == "click-bind-suspend") {
                a = "auto"
            }
            var c = navigator.userAgent.indexOf("compatible") > -1 && navigator.userAgent.indexOf("MSIE") > -1;
            g += '<div class="JDJRV-slide" style="width: ' + a + '">' + '<div class="JDJRV-img-panel ' + k + '">' + '<div class="JDJRV-refresh" style="margin-right: ' + e + '"><div class="JDJRV-lable-refresh">完成拼图验证</div><div class="JDJRV-img-refresh"><span>换一张</span><div></div></div></div>' + '<div class="JDJRV-img-wrap">' + '<div class="JDJRV-bigimg"><img src="" ' + (c ? 'height="0px"' : "") + "></div>" + '<div class="JDJRV-smallimg"><img src="" ' + (c ? 'height="0px"' : "") + "></div>" + "</div>" + "</div>" + '<div class="JDJRV-slide-bg">' + '<div class="JDJRV-slide-inner JDJRV-slide-text">' + '<div class="JDJRV-slide-left"></div>' + '<div class="JDJRV-slide-center">' + n + "</div>" + '<div class="JDJRV-slide-right"></div>' + "</div>" + '<div class="JDJRV-slide-inner JDJRV-slide-bar"><div class="JDJRV-slide-bar-left"></div><div class="JDJRV-slide-bar-center"></div><div class="JDJRV-slide-bar-right"></div></div>' + '<div class="JDJRV-slide-inner JDJRV-slide-btn"><!--<span class="JDJRV-slide-icon"></span>--></div></div>' + "</div>"
        }
        if (this.params.product == "bind" || this.params.product == "popup" || this.params.product == "click-popup") {
            g += "</div></div>";
            var o = document.createElement("div");
            o.innerHTML = g;
            var p = document.createDocumentFragment();
            while (o.firstChild) {
                p.appendChild(o.firstChild)
            }
            var i = this.gi("JDJRV-wrap-" + this.params.id);
            if (i) {
                document.body.removeChild(i)
            }
            document.body.appendChild(p);
            this.warp = this.gi("JDJRV-wrap-" + this.params.id);
            if (!this.warp.getElementsByClassName) {
                this.ge(this.warp)
            }
            this.closeBtn = this.warp.getElementsByClassName("JDJRV-close")[0];
            this.popContent = this.warp.getElementsByClassName("JDJRV-pop-content")[0];
            if (this.params.product == "popup") {
                this.clickWarp = this.gi(this.params.id);
                var d = '<div class="JDJRV-click-warp" style="width: ' + b + '"><img class="JDJRV-click-img" src="//ivs.jd.com/slide/i/wait.gif"><div class="JDJRV-click-text">点击完成验证</div></div>';
                this.clickWarp.innerHTML = d;
                if (!this.clickWarp.getElementsByClassName) {
                    this.ge(this.clickWarp)
                }
                this.clickContent = this.clickWarp.getElementsByClassName("JDJRV-click-warp")[0];
                this.clickImg = this.clickWarp.getElementsByClassName("JDJRV-click-img")[0];
                this.clickText = this.clickWarp.getElementsByClassName("JDJRV-click-text")[0]
            }
        } else {
            if (this.params.product == "click") {
                this.clickWarp = this.gi(this.params.id);
                var d = '<div class="JDJRV-click-warp" style="width: ' + b + '"><img class="JDJRV-click-img" src="//ivs.jd.com/slide/i/wait.gif"><div class="JDJRV-click-text">点击完成验证</div></div>';
                this.clickWarp.innerHTML = d;
                if (!this.clickWarp.getElementsByClassName) {
                    this.ge(this.clickWarp)
                }
                this.clickContent = this.clickWarp.getElementsByClassName("JDJRV-click-warp")[0];
                this.clickImg = this.clickWarp.getElementsByClassName("JDJRV-click-img")[0];
                this.clickText = this.clickWarp.getElementsByClassName("JDJRV-click-text")[0]
            } else {
                if (this.params.product == "click-bind" || this.params.product == "bind-suspend") {
                    this.clickWarp = this.gi(this.params.id);
                    if (!this.clickWarp.getElementsByClassName) {
                        this.ge(this.clickWarp)
                    }
                } else {
                    if (this.params.product == "suspend") {
                        this.warp = this.gi(this.params.id);
                        if (!this.warp.getElementsByClassName) {
                            this.ge(this.warp)
                        }
                        var f = this.params.height || "40px";
                        var d = '<div class="JDJRV-suspend-warp" style="width: ' + b + '"><div class="JDJRV-suspend-slide"></div><div class="JDJRV-suspend-click" style=";height:' + f + ";line-height:" + f + '">点击完成验证</div></div>';
                        this.warp.innerHTML = d;
                        this.clickWarp = this.warp.getElementsByClassName("JDJRV-suspend-click")[0];
                        this.clickContent = this.warp.getElementsByClassName("JDJRV-suspend-click")[0];
                        this.clickText = this.warp.getElementsByClassName("JDJRV-suspend-click")[0];
                        this.suspendSlideWarp = this.warp.getElementsByClassName("JDJRV-suspend-slide")[0];
                        this.suspendSlideWarp.style.bottom = this.clickWarp.offsetHeight + 6 + "px"
                    } else {
                        if (this.params.product == "click-suspend") {
                            g += "</div></div>";
                            this.suspendSlideWarp.innerHTML = g;
                            this.closeBtn = this.warp.getElementsByClassName("JDJRV-close")[0];
                            this.suspendSlideWarp.style.display = "block"
                        } else {
                            if (this.params.product == "click-bind-suspend") {
                                g += "</div></div></div></div>";
                                var o = document.createElement("div");
                                o.innerHTML = g;
                                var p = document.createDocumentFragment();
                                while (o.firstChild) {
                                    p.appendChild(o.firstChild)
                                }
                                var i = this.gi("JDJRV-wrap-" + this.params.id);
                                if (i) {
                                    document.body.removeChild(i)
                                }
                                document.body.appendChild(p);
                                this.warp = this.gi("JDJRV-wrap-" + this.params.id);
                                if (!this.warp.getElementsByClassName) {
                                    this.ge(this.warp)
                                }
                                this.suspendSlideWarp = this.warp.getElementsByClassName("JDJRV-suspend-slide")[0];
                                this.closeBtn = this.warp.getElementsByClassName("JDJRV-close")[0]
                            } else {
                                this.warp.innerHTML = g
                            }
                        }
                    }
                }
            }
        }
        if (this.params.product != "click" && this.params.product != "click-bind" && this.params.product != "suspend" && this.params.product != "bind-suspend") {
            if (this.params.product == "click-popup" || this.params.product == "click-suspend" || this.params.product == "click-bind-suspend") {
                j.iw()
            } else {
                setTimeout(function () {
                    j.iw()
                }, 50)
            }
        } else {
            setTimeout(function () {
                j.ic()
            }, 50)
        }
    },
    iw: function () {
        if (!this.warp.getElementsByClassName) {
            this.ge(this.warp)
        }
        this.slideWrap = this.warp.getElementsByClassName("JDJRV-slide")[0];
        this.width = this.slideWrap.offsetWidth;
        this.imgRatio = this.slideWrap.offsetWidth ? (360 / this.slideWrap.offsetWidth) : 1;
        this.slideBar = this.warp.getElementsByClassName("JDJRV-slide-bg")[0];
        this.slideBtn = this.warp.getElementsByClassName("JDJRV-slide-btn")[0];
        this.slideGreenBar = this.warp.getElementsByClassName("JDJRV-slide-bar")[0];
        this.slideGreenBarCenter = this.warp.getElementsByClassName("JDJRV-slide-bar-center")[0];
        this.slideSmallImg = this.warp.getElementsByClassName("JDJRV-smallimg")[0];
        this.slideBigImg = this.warp.getElementsByClassName("JDJRV-bigimg")[0];
        this.slideImgWrap = this.warp.getElementsByClassName("JDJRV-img-panel")[0];
        this.slideCenter = this.warp.getElementsByClassName("JDJRV-slide-center")[0];
        if (!this.slideImgWrap.getElementsByClassName) {
            this.ge(this.slideImgWrap)
        }
        this.refreshBtn = this.slideImgWrap.getElementsByClassName("JDJRV-img-refresh")[0];
        this.slideText = this.warp.getElementsByClassName("JDJRV-slide-text")[0];
        this.slideBigImg.style.height = 140 / (360 / this.slideWrap.offsetWidth) + "px";
        this.vi();
        this.be()
    },
    ic: function () {
        var c = this;
        c.vi();
        if (c.params.eventListener == false || c.params.eventListener == "false") {
            c.verify = b
        } else {
            c.clickWarp.onclick = b;
            if (c.params.formId) {
                document.getElementById(c.params.formId).onsubmit = function () {
                    b();
                    return false
                }
            }
        }
        document.onmousemove = a;
        document.ontouchmove = a;

        function a(e) {
            if (c.params.product == "click" || c.params.product == "click-bind" || c.params.product == "suspend" || c.params.product == "bind-suspend") {
                var d = e || event;
                if (d.touches) {
                    d = d.touches[0]
                }
                c.clickProductData.push([d.clientX.toFixed(0), d.clientY.toFixed(0), new Date().getTime()])
            }
        }
        function b() {
            if (!c.clickResult) {
                if (c.params.product == "click-popup") {
                    c.warp.style.display = "block";
                    c.rs()
                } else {
                    if (c.params.product == "click-suspend") {
                        c.suspendSlideWarp.style.display = "block";
                        c.rs()
                    } else {
                        if (c.params.product == "click-bind-suspend") {
                            c.warp.style.display = "block";
                            c.rs()
                        } else {
                            c.sb()
                        }
                    }
                }
            }
        }
    },
    be: function () {
        var e = this;
        if (e.params.product == "click-popup") {
            e.closeBtn.onclick = function () {
                e.warp.style.display = "none"
            }
        }
        if (e.params.product == "click-suspend") {
            e.closeBtn.onclick = function () {
                e.suspendSlideWarp.style.display = "none"
            }
        }
        if (e.params.product == "click-bind-suspend") {
            e.closeBtn.onclick = function () {
                e.warp.style.display = "none"
            }
        }
        if (e.params.product == "popup") {
            e.clickWarp.onclick = function () {
                e.warp.style.display = "block";
                e.rs()
            };
            e.closeBtn.onclick = function () {
                e.warp.style.display = "none"
            }
        }
        if (e.params.product == "bind") {
            if (e.params.eventListener == false || e.params.eventListener == "false") {
                e.verify = function () {
                    e.warp.style.display = "block";
                    e.rs()
                }
            } else {
                document.getElementById(e.params.id).onclick = function () {
                    e.warp.style.display = "block";
                    e.rs()
                }
            }
            e.closeBtn.onclick = function () {
                e.warp.style.display = "none"
            }
        }
        e.slideBtn.onmousedown = d;
        e.slideBtn.ontouchstart = d;

        function d(i) {
            if (e.passValidate) {
                return
            }
            e.isDraging = true;
            var h = i || event;
            if (document.all) {
                window.event.returnValue = false;
                window.event.cancelBubble = true
            } else {
                h.preventDefault();
                h.stopPropagation();
                h.returnValue = false
            }
            if (h.touches) {
                h = h.touches[0]
            }
            e.disX = h.clientX;
            e.slideGreenBar.style.display = "block";
            e.mousePos = [];
            e.mousePos.push([e.gl(e.slideBtn).toFixed(0), e.gt(e.slideBtn).toFixed(0), new Date().getTime()]);
            e.mousePos.push([h.clientX.toFixed(0), h.clientY.toFixed(0), new Date().getTime()]);
            document.onmousemove = g;
            document.ontouchmove = g;
            document.onmouseup = f;
            document.ontouchend = f;

            function g(m) {
                var k = m || event;
                if (document.all) {
                    window.event.returnValue = false;
                    window.event.cancelBubble = true
                } else {
                    k.preventDefault();
                    k.stopPropagation();
                    k.returnValue = false
                }
                if (k.touches) {
                    k = k.touches[0]
                }
                var l = k.clientX - e.disX + 40;
                var n = k.clientX - e.disX;
                var j = k.clientX - e.disX;
                if (j < 0) {
                    j = 0
                } else {
                    if (j > e.width - (50 / e.imgRatio)) {
                        j = e.width - (50 / e.imgRatio)
                    }
                }
                if (n < 0) {
                    n = 0
                } else {
                    if (n > e.width - 40) {
                        n = e.width - 40
                    }
                }
                if (l < 44) {
                    l = 44
                } else {
                    if (l > e.width) {
                        l = e.width
                    }
                }
                e.mousePos.push([k.clientX.toFixed(0), k.clientY.toFixed(0), new Date().getTime()]);
                e.slideBtn.style.left = n + "px";
                e.slideSmallImg.style.left = j + "px";
                e.slideGreenBar.style.width = l + "px";
                return false
            }
            function f(k) {
                var j = k || event;
                if (j.changedTouches) {
                    j = j.changedTouches[0]
                }
                e.isDraging = false;
                e.mousePos.push([j.clientX.toFixed(0), j.clientY.toFixed(0), new Date().getTime()]);
                document.onmousemove = null;
                document.ontouchmove = null;
                document.onmouseup = null;
                document.ontouchend = null;
                if (e.mousePos.length <= 3) {
                    e.slideGreenBar.style.display = "none";
                    e.slideText.setAttribute("class", "JDJRV-slide-inner JDJRV-slide-text");
                    e.slideText.setAttribute("className", "JDJRV-slide-inner JDJRV-slide-text");
                    return
                }
                e.sb()
            }
        }
        if (this.params.product == "float") {
            var c = false;
            var b = false;
            this.slideImgWrap.onmouseover = function () {
                c = true
            };
            this.slideImgWrap.onmouseout = function () {
                c = false;
                e.slideTimer = setTimeout(function () {
                    if (c || b) {
                        return
                    }
                    e.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float");
                    e.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float ")
                }, 300)
            };
            this.slideBar.onmouseover = function () {
                b = true;
                if (e.passValidate || e.isDraging) {
                    return
                }
                clearTimeout(e.slideTimer);
                e.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float JDJRV-float-hover");
                e.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float JDJRV-float-hover")
            };
            this.slideBar.onmouseout = function () {
                b = false;
                if (e.isDraging) {
                    return
                }
                e.slideTimer = setTimeout(function () {
                    if (c) {
                        return
                    }
                    e.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float");
                    e.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float ")
                }, 300)
            }
        }
        this.refreshBtn.onclick = function () {
            if (e.passValidate || e.isDraging) {
                return
            }
            e.vi();
            if (e.params.refreshCallback) {
                e.callback({
                    getSuccess: function () {
                        return "2"
                    },
                    getMessage: function () {
                        return "refresh"
                    },
                    getValidate: function () {
                        return ""
                    }
                })
            }
        };
        var a = 0;
        window.onresize = function () {
            e.rs()
        }
    },
    it: function () {
        var a = this;
        if (a.params.getInstance) {
            a.params.getInstance(a)
        }
    },
    rs: function () {
        var d = this;
        if (d.y) {
            d.width = d.slideWrap.offsetWidth;
            var b = d.imgRatio;
            d.imgRatio = d.slideWrap.offsetWidth ? (360 / d.slideWrap.offsetWidth) : 0;
            d.slideSmallImg.style.top = d.y / d.imgRatio + "px";
            d.slideSmallImg.style.width = 50 / d.imgRatio + "px";
            d.slideBigImg.style.height = 140 / (360 / d.slideWrap.offsetWidth) + "px";
            d.slideSmallImg.style.left = d.slideSmallImg.offsetLeft * b / d.imgRatio + "px"
        }
        if (d.params.product == "bind" || d.params.product == "popup" || d.params.product == "click-popup") {
            d.popContent.style.marginLeft = d.popContent.offsetWidth < 360 ? (document.body.clientWidth * (-0.45) + "px") : (d.popContent.offsetWidth / 2 * -1 + "px")
        }
        if (d.params.product == "click-bind-suspend" && d.slideWrap) {
            var a = d.clickWarp.getBoundingClientRect().left + document.documentElement.scrollLeft;
            var c = d.clickWarp.getBoundingClientRect().top + document.documentElement.scrollTop;
            c -= 140 / (360 / d.slideWrap.offsetWidth) + 120;
            d.warp.style.top = c + "px";
            d.warp.style.left = a + "px"
        }
    },
    rv: function () {
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
    vi: function () {
        var a = this;
        //修改by:余观成 2018.9.8
        a.aj({
            url: "?action=get_img&appid=" + a.params.appId + "&scene=&product=" + a.params.scene + "&e=" + a.params.product,
            success: function (b) {
                b = eval("(" + b + ")");
                if (a.params.product != "click" && a.params.product != "click-bind" && a.params.product != "suspend" && a.params.product != "bind-suspend") {
                    a.slideBigImg.innerHTML = '<img src="' + a.is(b.static_servers, b.bg) + '">';
                    a.slideSmallImg.innerHTML = '<img src="' + a.is(b.static_servers, b.patch) + '">';
                    a.y = b.y;
                    a.slideSmallImg.style.top = b.y / a.imgRatio + "px";
                    a.slideSmallImg.style.width = 50 / a.imgRatio + "px";
                    a.slideSmallImg.style.left = 0 + "px"
                }
                a.validateID = b.challenge;
                setTimeout(function () {
                    a.rs()
                }, 1)
            }
        });
        return;
        //修改by:余观成 2018.9.8
        var a = this;
        a.jp("//iv.jd.com/slide/g.html", {
            appId: a.params.appId,
            scene: a.params.scene,
            product: a.params.product,
            e: a.ei()
        }, "callback", function (b) {
            if (a.params.product != "click" && a.params.product != "click-bind" && a.params.product != "suspend" && a.params.product != "bind-suspend") {
                a.slideBigImg.innerHTML = '<img src="' + a.is(b.static_servers, b.bg) + '">';
                a.slideSmallImg.innerHTML = '<img src="' + a.is(b.static_servers, b.patch) + '">';
                a.y = b.y;
                a.slideSmallImg.style.top = b.y / a.imgRatio + "px";
                a.slideSmallImg.style.width = 50 / a.imgRatio + "px";
                a.slideSmallImg.style.left = 0 + "px"
            }
            a.validateID = b.challenge;
            setTimeout(function () {
                a.rs()
            }, 1)
        });
    },
    sb: function () {
        var c = this;
        var b;
        if (c.params.product == "click" || c.params.product == "click-bind" || c.params.product == "suspend" || c.params.product == "bind-suspend") {
            b = c.clickProductData;
            var a = b.length;
            if (a > 300) {
                b = c.clickProductData.slice(a - 300, a)
            }
        } else {
            b = c.mousePos
        }

        //修改by:余观成 2018.9.8
        var obj_submit = {
            d: c.gc(b),
            c: c.validateID,
            w: c.width ? c.width.toFixed(0) : 0,
            appId: c.params.appId,
            scene: c.params.scene,
            product: c.params.product,
            e: c.ei(),
            s: c.si()
        };
        console.log(obj_submit);
        c.aj({
            url: "?action=submit&d=" + obj_submit.d + "&c=" + obj_submit.c + "&w=" + obj_submit.w + "&s=" + obj_submit.s + "&appid=" + obj_submit.appId + "&scene=&product=" + obj_submit.scene + "&e=" + obj_submit.product,
            success: function (d) {
                d = eval("(" + d + ")");
                console.log(d);
                if (c.params.product == "click" || c.params.product == "click-bind" || c.params.product == "suspend" || c.params.product == "bind-suspend") {
                    if (d.success == 0) {
                        if (c.params.product == "suspend") {
                            c.params.product = "click-suspend"
                        } else {
                            if (c.params.product == "bind-suspend") {
                                c.params.product = "click-bind-suspend"
                            } else {
                                c.params.product = "click-popup"
                            }
                        }
                        c.ih();
                        c.warp.style.display = "block";
                        c.rs()
                    } else {
                        c.cs()
                    }
                } else {
                    if (d.success == 0) {
                        c.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-err");
                        c.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-err");
                        setTimeout(function () {
                            c.vi()
                        }, 500);
                        c.rv()
                    } else {
                        c.passValidate = true;
                        c.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-succ");
                        c.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-succ");
                        c.slideGreenBar.style.width = "100%";
                        c.slideGreenBarCenter.innerHTML = c.params.successMess ? c.params.successMess : "拼接成功";
                        c.refreshBtn.style.display = "none";
                        if (c.params.product == "float") {
                            c.slideTimer = setTimeout(function () {
                                c.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float");
                                c.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float")
                            }, 300)
                        }
                        if (c.params.product == "bind" || c.params.product == "popup" || c.params.product == "click-popup" || c.params.product == "click-bind-suspend") {
                            setTimeout(function () {
                                c.warp.style.display = "none"
                            }, 800)
                        }
                        if (c.params.product == "popup" || c.params.product == "click-popup" || c.params.product == "click-suspend") {
                            c.cs()
                        }
                    }
                }
                c.sc(d);
            }
        });
        return;
        //修改by:余观成 2018.9.8
        c.jp("//iv.jd.com/slide/s.html", {
            d: c.gc(b),
            c: c.validateID,
            w: c.width ? c.width.toFixed(0) : 0,
            appId: c.params.appId,
            scene: c.params.scene,
            product: c.params.product,
            e: c.ei(),
            s: c.si()
        }, "callback", function (d) {
            if (c.params.product == "click" || c.params.product == "click-bind" || c.params.product == "suspend" || c.params.product == "bind-suspend") {
                if (d.success == 0) {
                    if (c.params.product == "suspend") {
                        c.params.product = "click-suspend"
                    } else {
                        if (c.params.product == "bind-suspend") {
                            c.params.product = "click-bind-suspend"
                        } else {
                            c.params.product = "click-popup"
                        }
                    }
                    c.ih();
                    c.warp.style.display = "block";
                    c.rs()
                } else {
                    c.cs()
                }
            } else {
                if (d.success == 0) {
                    c.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-err");
                    c.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-err");
                    setTimeout(function () {
                        c.vi()
                    }, 500);
                    c.rv()
                } else {
                    c.passValidate = true;
                    c.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-succ");
                    c.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-succ");
                    c.slideGreenBar.style.width = "100%";
                    c.slideGreenBarCenter.innerHTML = c.params.successMess ? c.params.successMess : "拼接成功";
                    c.refreshBtn.style.display = "none";
                    if (c.params.product == "float") {
                        c.slideTimer = setTimeout(function () {
                            c.slideImgWrap.setAttribute("class", "JDJRV-img-panel JDJRV-float");
                            c.slideImgWrap.setAttribute("className", "JDJRV-img-panel JDJRV-float")
                        }, 300)
                    }
                    if (c.params.product == "bind" || c.params.product == "popup" || c.params.product == "click-popup" || c.params.product == "click-bind-suspend") {
                        setTimeout(function () {
                            c.warp.style.display = "none"
                        }, 800)
                    }
                    if (c.params.product == "popup" || c.params.product == "click-popup" || c.params.product == "click-suspend") {
                        c.cs()
                    }
                }
            }
            c.sc(d)
        }, function () {
            if (c.params.product == "click" || c.params.product == "click-bind") {
                c.params.product = "click-popup";
                c.ih();
                c.warp.style.display = "block";
                setTimeout(function () {
                    c.rs()
                }, 50)
            } else {
                c.slideWrap.setAttribute("class", "JDJRV-slide JDJRV-slide-err");
                c.slideWrap.setAttribute("className", "JDJRV-slide JDJRV-slide-err");
                setTimeout(function () {
                    c.vi()
                }, 500);
                c.rv()
            }
        })
    },
    sc: function (b) {
        var c = this;
        var a = {};
        a.getSuccess = function () {
            return b.success
        };
        a.getMessage = function () {
            return b.message
        };
        a.getValidate = function () {
            return ""
        };
        if (b.success == 0) {
            if (c.params.failCallback) {
                c.callback(a)
            }
        } else {
            a.getValidate = function () {
                return b.validate
            };
            c.callback(a)
        }
    },
    cs: function () {
        var a = this;
        if (a.clickContent) {
            if (a.params.product == "suspend") {
                a.clickContent.setAttribute("class", "JDJRV-suspend-click JDJRV-suspend-click-success");
                a.clickContent.setAttribute("className", "JDJRV-suspend-click JDJRV-suspend-click-success");
                a.clickText.innerHTML = a.params.successMess ? a.params.successMess : "验证成功"
            } else {
                if (a.params.product == "click-suspend") {
                    a.clickContent.setAttribute("class", "JDJRV-suspend-click JDJRV-suspend-click-success");
                    a.clickContent.setAttribute("className", "JDJRV-suspend-click JDJRV-suspend-click-success");
                    a.clickText.innerHTML = a.params.successMess ? a.params.successMess : "验证成功";
                    a.suspendSlideWarp.style.display = "none"
                } else {
                    a.clickContent.setAttribute("class", "JDJRV-click-warp JDJRV-click-success");
                    a.clickContent.setAttribute("className", "JDJRV-click-warp JDJRV-click-success");
                    a.clickImg.src = "//ivs.jd.com/slide/i/slide-succ.png";
                    a.clickText.innerHTML = a.params.successMess ? a.params.successMess : "验证成功"
                }
            }
        }
        a.clickResult = true
    },
    is: function (b, a) {
        return ((a.lastIndexOf(".png") > 0 || a.lastIndexOf(".jpg") > 0 || a.lastIndexOf(".webp") > 0) ? b : "data:image/png;base64,") + a
    },
    jp: function (b, h, l, m, k) {
        var d = "jsonp_" + Math.random();
        d = d.replace(".", "");
        window[d] = function (i) {
            clearTimeout(c);
            window[d] = null;
            f.removeChild(e);
            m(i)
        };
        var c = setTimeout(function () {
            window[d] = null;
            f.removeChild(e);
            k && k()
        }, 5000);
        h[l] = d;
        var j = [];
        for (var g in h) {
            j.push(g + "=" + h[g])
        }
        var a = b + "?" + j.join("&");
        var e = document.createElement("script");
        e.src = a;
        e.type = "text/javascript";
        var f = document.getElementsByTagName("head")[0];
        f.appendChild(e)
    },
    aj: function (a) {
        a = a || {};
        a.type = (a.type || "GET").toUpperCase();
        a.dataType = a.dataType || "json";
        var c = this.fp(a.data);
        if (window.XMLHttpRequest) {
            var b = new XMLHttpRequest()
        } else {
            var b = new ActiveXObject("Microsoft.XMLHTTP")
        }
        b.onreadystatechange = function () {
            if (b.readyState == 4) {
                var d = b.status;
                if (d >= 200 && d < 300) {
                    a.success && a.success(b.responseText, b.responseXML)
                } else {
                    a.fail && a.fail(d)
                }
            }
        };
        if (a.type == "GET") {
            b.open("GET", a.url + "?" + c, true);
            b.send(null)
        } else {
            if (a.type == "POST") {
                b.open("POST", a.url, true);
                b.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                b.send(c)
            }
        }
    },
    fp: function (c) {
        var a = [];
        for (var b in c) {
            a.push(encodeURIComponent(b) + "=" + encodeURIComponent(c[b]))
        }
        a.push(("v=" + Math.random()).replace(".", ""));
        return a.join("&")
    },
    st: function (d) {
        var c = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-~".split(""),
            b = c.length,
            e = +d,
            a = [];
        do {
            mod = e % b;
            e = (e - mod) / b;
            a.unshift(c[mod])
        } while (e);
        return a.join("")
    },
    pi: function (a, b) {
        return (Array(b).join(0) + a).slice(-b)
    },
    pm: function (d, c, b) {
        var f = this;
        var e = f.st(Math.abs(d));
        var a = "";
        if (!b) {
            a += (d > 0 ? "1" : "0")
        }
        a += f.pi(e, c);
        return a
    },
    gc: function (c) {
        var g = this;
        var b = new Array();
        for (var e = 0; e < c.length; e++) {
            if (e == 0) {
                b.push(g.pm(c[e][0] < 262143 ? c[e][0] : 262143, 3, true));
                b.push(g.pm(c[e][1] < 16777215 ? c[e][1] : 16777215, 4, true));
                b.push(g.pm(c[e][2] < 4398046511103 ? c[e][2] : 4398046511103, 7, true))
            } else {
                var a = c[e][0] - c[e - 1][0];
                var f = c[e][1] - c[e - 1][1];
                var d = c[e][2] - c[e - 1][2];
                b.push(g.pm(a < 4095 ? a : 4095, 2, false));
                b.push(g.pm(f < 4095 ? f : 4095, 2, false));
                b.push(g.pm(d < 16777215 ? d : 16777215, 4, true))
            }
        }
        return b.join("")
    },
    ei: function () {
        var a = "";
        try {
            a = getJdEid().eid
        } catch (b) { }
        try {
            if (a == "") {
                getJdEid(function (d, e, c) {
                    a = d
                })
            }
        } catch (b) { }
        return a
    },
    si: function () {
        var b = "";
        try {
            if ("undefined" != typeof _jdtdmap_sessionId) {
                b = _jdtdmap_sessionId
            }
        } catch (a) {
            console.error("sessionId err;")
        }
        return b
    },
    gl: function (a) {
        var c = this;
        var b = a.offsetLeft;
        if (a.offsetParent != null) {
            b += c.gl(a.offsetParent)
        }
        return b
    },
    gt: function (a) {
        var c = this;
        var b = a.offsetTop;
        if (a.offsetParent != null) {
            b += c.gt(a.offsetParent)
        }
        return b
    }
};