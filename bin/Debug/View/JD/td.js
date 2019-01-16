function td_collect_exe() {
    !
        function () {
            var e = _JdJrTdRiskFp.getData();
            !
                function (e, q, v) {
                    _JdJrRiskClientStorage.get("3AB9D23F7A4B3C9B", function (m) {
                        var t = {
                            pin: _jdJrTdCommonsObtainPin(),
                            oid: e,
                            p: "https:" == document.location.protocol ? "s" : "h",
                            fp: v,
                            v: "2.4.2.1"
                        };
                        try {
                            t.o = _CurrentPageUrl
                        } catch (A) { }
                        void 0 !== m && null !== m && 0 < m.length && (_JdEid = m, _eidFlag = !0);
                        void 0 !== _JdEid && 0 < _JdEid.length && (t.fc = _JdEid);
                        m = !1;
                        m = navigator.userAgent;
                        m = 0 < m.indexOf("MSIE 7.0") || 0 < m.indexOf("MSIE 8.0") || 0 < m.indexOf("MSIE 9.0");
                        try {
                            t.t = jd_risk_token_id
                        } catch (A) { }
                        t = "?a=" + (m ? encodeURIComponent(td_collect.tdencrypt(t)) : td_collect.tdencrypt(t));
                        _JdJrRiskClientCollectData = td_collect.collect();
                        m = [];
                        m.g = td_collect.tdencrypt(q);
                        m.d = _JdJrRiskClientCollectData;
                        jdJrTdsendCorsRequest(document.location.protocol + "//" + _JdJrTdRiskDomainName + "/fcf.html" + t, m, t, function (e) {
                            32 <= e.length && 91 >= e.length && (_JdEid = e, _eidFlag = !0, _JdJrRiskClientStorage.set("3AB9D23F7A4B3C9B", e), _jdJrTdRelationEidPin(_JdEid), _JdJrReleaseResource())
                        })
                    })
                }("string" == typeof orderId ? orderId : "", e, _JdJrTdRiskFpInfo)
        }()
}
function jdJrTdsendCorsRequest(e, m, q, v) {
    try {
        var x = navigator.userAgent;
        if (0 < x.indexOf("MSIE") && (0 < x.indexOf("MSIE 7.0") || 0 < x.indexOf("MSIE 8.0") || 0 < x.indexOf("MSIE 9.0"))) return q += "&g=" + encodeURIComponent(m.g), jdJrTdsendJsonpRequest("fc.html", q);
        try {
            var t = new window.XMLHttpRequest
        } catch (p) { }
        if (!t) try {
            t = new window.ActiveXObject("Microsoft.XMLHTTP")
        } catch (p) { }
        if (!t) try {
            t = new window.ActiveXObject("Msxml2.XMLHTTP")
        } catch (p) { }
        if (!t) try {
            t = new window.ActiveXObject("Msxml3.XMLHTTP")
        } catch (p) { }
        t.open("POST", e, !0);
        t.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
        t.onreadystatechange = function () {
            4 === t.readyState && 200 === t.status && v(t.responseText)
        };
        e = "";
        for (var A in m) e += ("" == e ? "" : "&") + A + "=" + m[A];
        t.send(e)
    } catch (p) { }
}
function jdJrTdsendJsonpRequest(e, m) {
    try {
        var q = document.createElement("script");
        q.src = _CurrentPageProtocol + _JdJrTdRiskDomainName + "/" + e + m;
        document.body.appendChild(q)
    } catch (v) { }
}
function _JdJrReleaseResource() {
    var e = document.getElementById("userdata_el");
    e && e.parentNode && e.parentNode.removeChild(e);
    _JdJrRiskClientStorage = _JdJrTdRiskFp = _JdJrRiskClientCollectData = null
}
function callEidfingerRisk_3AB9D23F7A4B3C9B(e) {
    try {
        32 <= e.length && (_eidFlag = !0, _JdEid = e, _JdJrRiskClientStorage.set("3AB9D23F7A4B3C9B", e), _jdJrTdRelationEidPin(e)), _JdJrReleaseResource()
    } catch (m) { }
}
function getJdEid(e, m, q) {
    if ("function" != typeof e) throw Error("callback must be a function.");
    if (void 0 === m && (m = 1), void 0 === q && (q = 15), !_eidFlag && m < q) setTimeout(function () {
        getJdEid(e, m, q)
    }, 15 * m), m++;
    else {
        _JdTdudfp.eid = !_JdEid || 120 < _JdEid.length ? "" : _JdEid;
        _JdTdudfp.fp = _JdJrTdRiskFpInfo;
        try {
            _JdTdudfp.date = Date.parse(new Date), _JdTdudfp.token = "string" == typeof jd_risk_token_id ? jd_risk_token_id : ""
        } catch (v) { }
        e(_JdEid, _JdJrTdRiskFpInfo, _JdTdudfp)
    }
}
function JdJrTdFingerDataStream(e, m, q) {
    if (void 0 === e || 0 == e) throw Error("sourceCode can not be null.");
    if (void 0 === m && (m = 1), void 0 === q && (q = 15), !_eidFlag && m < q) setTimeout(function () {
        JdJrTdFingerDataStream(e, m, q)
    }, 20 * m), m++;
    else if ("undefined" != typeof jd_risk_token_id && 0 < _JdEid.length && 0 < _JdJrTdRiskFpInfo.length) {
        var v = _jdJrTdCommonsObtainPin();
        0 < v.length && (v = {
            p: v,
            fp: _JdJrTdRiskFpInfo,
            e: _JdEid,
            ct: (new Date).getTime(),
            t: jd_risk_token_id,
            opt: e
        }, jdJrTdsendJsonpRequest("stream.html", "?c=" + td_collect.tdencrypt(v)))
    }
}
function _jdJrTdRelationEidPin(e) {
    try {
        if (32 <= e.length) {
            var m = _jdJrTdCommonsObtainPin();
            if (0 < m.length) {
                e = {
                    o: _CurrentPageUrl,
                    p: m,
                    e: e,
                    f: _JdJrTdRiskFpInfo
                };
                var q = navigator.userAgent,
                    v = 0 < q.indexOf("MSIE 7.0") || 0 < q.indexOf("MSIE 8.0") || 0 < q.indexOf("MSIE 9.0") ? encodeURIComponent(td_collect.tdencrypt(e)) : td_collect.tdencrypt(e);
                jdJrTdsendJsonpRequest("r.html?v=" + Math.random() + "&d=" + v, "")
            }
        }
    } catch (x) { }
}
function _jdJrTdCommonsObtainPin() {
    var e = "";
    return "string" == typeof pin ? e = pin : "object" == typeof pin && "string" == typeof jd_jr_td_risk_pin && (e = jd_jr_td_risk_pin), e
}
var start_time = (new Date).getTime(),
    _CurrentPageProtocol = "https:" == document.location.protocol ? "https://" : "http://",
    _JdJrTdRiskDomainName = "gia.jd.com";
if (void 0 === _jd_load_td_finger_flag) {
    var _jd_load_td_finger_flag = !0,
        _jdfp_canvas_md5 = "",
        _jdfp_webgl_md5 = "",
        use_breakcollect = !0,
        _CurrentPageUrl = function () {
            var e = document.location.href.toString(),
                m = e.indexOf("?");
            0 < m && (e = e.substring(0, m));
            var q = (e = e.substring(_CurrentPageProtocol.length)).indexOf("joybuy.com");
            return -1 < q && (-1 == m || q < m) && (_JdJrTdRiskDomainName = "gia.joybuy.com"), e
        }();
    try {
        "undefined" == typeof _jd_load_td_finger_switch || _jd_load_td_finger_switch || (_jd_load_td_finger_flag = !1)
    } catch (e) { } !
        function () {
            if (_jd_load_td_finger_flag) {
                var e = document.createElement("script");
                e.src = _CurrentPageProtocol + _JdJrTdRiskDomainName + "/y.html?v=" + Math.random() + "&o=" + _CurrentPageUrl;
                e.async = !1;
                document.body.appendChild(e);
            }
        }();
    (function (e, m, q) {
        "undefined" != typeof module && module.exports ? module.exports = q() : m.JdJrTdRiskFinger = q()
    })(0, this, function () {
        function e(a) {
            if (null == a || void 0 == a || "" == a) var c = "undefined";
            else {
                if (null == a || void 0 == a || "" == a) c = "";
                else {
                    c = [];
                    for (var b = (1 << r) - 1, g = 0; g < a.length * r; g += r) c[g >> 5] |= (a.charCodeAt(g / r) & b) << g % 32
                }
                a = a.length * r;
                c[a >> 5] |= 128 << a % 32;
                c[14 + (a + 64 >>> 9 << 4)] = a;
                a = 1732584193;
                b = -271733879;
                g = -1732584194;
                for (var f = 271733878, h = 0; h < c.length; h += 16) {
                    var d = a,
                        w = b,
                        l = g,
                        k = f;
                    b = t(b = t(b = t(b = t(b = x(b = x(b = x(b = x(b = v(b = v(b = v(b = v(b = q(b = q(b = q(b = q(b, g = q(g, f = q(f, a = q(a, b, g, f, c[h + 0], 7, -680876936), b, g, c[h + 1], 12, -389564586), a, b, c[h + 2], 17, 606105819), f, a, c[h + 3], 22, -1044525330), g = q(g, f = q(f, a = q(a, b, g, f, c[h + 4], 7, -176418897), b, g, c[h + 5], 12, 1200080426), a, b, c[h + 6], 17, -1473231341), f, a, c[h + 7], 22, -45705983), g = q(g, f = q(f, a = q(a, b, g, f, c[h + 8], 7, 1770035416), b, g, c[h + 9], 12, -1958414417), a, b, c[h + 10], 17, -42063), f, a, c[h + 11], 22, -1990404162), g = q(g, f = q(f, a = q(a, b, g, f, c[h + 12], 7, 1804603682), b, g, c[h + 13], 12, -40341101), a, b, c[h + 14], 17, -1502002290), f, a, c[h + 15], 22, 1236535329), g = v(g, f = v(f, a = v(a, b, g, f, c[h + 1], 5, -165796510), b, g, c[h + 6], 9, -1069501632), a, b, c[h + 11], 14, 643717713), f, a, c[h + 0], 20, -373897302), g = v(g, f = v(f, a = v(a, b, g, f, c[h + 5], 5, -701558691), b, g, c[h + 10], 9, 38016083), a, b, c[h + 15], 14, -660478335), f, a, c[h + 4], 20, -405537848), g = v(g, f = v(f, a = v(a, b, g, f, c[h + 9], 5, 568446438), b, g, c[h + 14], 9, -1019803690), a, b, c[h + 3], 14, -187363961), f, a, c[h + 8], 20, 1163531501), g = v(g, f = v(f, a = v(a, b, g, f, c[h + 13], 5, -1444681467), b, g, c[h + 2], 9, -51403784), a, b, c[h + 7], 14, 1735328473), f, a, c[h + 12], 20, -1926607734), g = x(g, f = x(f, a = x(a, b, g, f, c[h + 5], 4, -378558), b, g, c[h + 8], 11, -2022574463), a, b, c[h + 11], 16, 1839030562), f, a, c[h + 14], 23, -35309556), g = x(g, f = x(f, a = x(a, b, g, f, c[h + 1], 4, -1530992060), b, g, c[h + 4], 11, 1272893353), a, b, c[h + 7], 16, -155497632), f, a, c[h + 10], 23, -1094730640), g = x(g, f = x(f, a = x(a, b, g, f, c[h + 13], 4, 681279174), b, g, c[h + 0], 11, -358537222), a, b, c[h + 3], 16, -722521979), f, a, c[h + 6], 23, 76029189), g = x(g, f = x(f, a = x(a, b, g, f, c[h + 9], 4, -640364487), b, g, c[h + 12], 11, -421815835), a, b, c[h + 15], 16, 530742520), f, a, c[h + 2], 23, -995338651), g = t(g, f = t(f, a = t(a, b, g, f, c[h + 0], 6, -198630844), b, g, c[h + 7], 10, 1126891415), a, b, c[h + 14], 15, -1416354905), f, a, c[h + 5], 21, -57434055), g = t(g, f = t(f, a = t(a, b, g, f, c[h + 12], 6, 1700485571), b, g, c[h + 3], 10, -1894986606), a, b, c[h + 10], 15, -1051523), f, a, c[h + 1], 21, -2054922799), g = t(g, f = t(f, a = t(a, b, g, f, c[h + 8], 6, 1873313359), b, g, c[h + 15], 10, -30611744), a, b, c[h + 6], 15, -1560198380), f, a, c[h + 13], 21, 1309151649), g = t(g, f = t(f, a = t(a, b, g, f, c[h + 4], 6, -145523070), b, g, c[h + 11], 10, -1120210379), a, b, c[h + 2], 15, 718787259), f, a, c[h + 9], 21, -343485551);
                    a = A(a, d);
                    b = A(b, w);
                    g = A(g, l);
                    f = A(f, k)
                }
                c = [a, b, g, f];
                a = p ? "0123456789ABCDEF" : "0123456789abcdef";
                b = "";
                for (g = 0; g < 4 * c.length; g++) b += a.charAt(c[g >> 2] >> g % 4 * 8 + 4 & 15) + a.charAt(c[g >> 2] >> g % 4 * 8 & 15);
                c = b
            }
            return c
        }
        function m(a, c, b, g, f, h) {
            a = A(A(c, a), A(g, h));
            return A(a << f | a >>> 32 - f, b)
        }
        function q(a, c, b, g, f, h, d) {
            return m(c & b | ~c & g, a, c, f, h, d)
        }
        function v(a, c, b, g, f, h, d) {
            return m(c & g | b & ~g, a, c, f, h, d)
        }
        function x(a, c, b, g, f, h, d) {
            return m(c ^ b ^ g, a, c, f, h, d)
        }
        function t(a, c, b, g, f, h, d) {
            return m(b ^ (c | ~g), a, c, f, h, d)
        }
        function A(a, c) {
            var b = (65535 & a) + (65535 & c);
            return (a >> 16) + (c >> 16) + (b >> 16) << 16 | 65535 & b
        }
        var p = 0,
            r = 8,
            u = {},
            d = navigator.userAgent.toLowerCase(),
            B = navigator.language || navigator.browserLanguage; - 1 == d.indexOf("ipad") && -1 == d.indexOf("iphone os") && -1 == d.indexOf("midp") && -1 == d.indexOf("rv:1.2.3.4") && -1 == d.indexOf("ucweb") && -1 == d.indexOf("android") && -1 == d.indexOf("windows ce") && d.indexOf("windows mobile");
        var l = "NA",
            z = "NA";
        try {
            -1 != d.indexOf("win") && -1 != d.indexOf("95") && (l = "windows", z = "95"), -1 != d.indexOf("win") && -1 != d.indexOf("98") && (l = "windows", z = "98"), -1 != d.indexOf("win 9x") && -1 != d.indexOf("4.90") && (l = "windows", z = "me"), -1 != d.indexOf("win") && -1 != d.indexOf("nt 5.0") && (l = "windows", z = "2000"), -1 != d.indexOf("win") && -1 != d.indexOf("nt") && (l = "windows", z = "NT"), -1 != d.indexOf("win") && -1 != d.indexOf("nt 5.1") && (l = "windows", z = "xp"), -1 != d.indexOf("win") && -1 != d.indexOf("32") && (l = "windows", z = "32"), -1 != d.indexOf("win") && -1 != d.indexOf("nt 5.1") && (l = "windows", z = "7"), -1 != d.indexOf("win") && -1 != d.indexOf("6.0") && (l = "windows", z = "8"), -1 == d.indexOf("win") || -1 == d.indexOf("nt 6.0") && -1 == d.indexOf("nt 6.1") || (l = "windows", z = "9"), -1 != d.indexOf("win") && -1 != d.indexOf("nt 6.2") && (l = "windows", z = "10"), -1 != d.indexOf("linux") && (l = "linux"), -1 != d.indexOf("unix") && (l = "unix"), -1 != d.indexOf("sun") && -1 != d.indexOf("os") && (l = "sun os"), -1 != d.indexOf("ibm") && -1 != d.indexOf("os") && (l = "ibm os/2"), -1 != d.indexOf("mac") && -1 != d.indexOf("pc") && (l = "mac"), -1 != d.indexOf("aix") && (l = "aix"), -1 != d.indexOf("powerpc") && (l = "powerPC"), -1 != d.indexOf("hpux") && (l = "hpux"), -1 != d.indexOf("netbsd") && (l = "NetBSD"), -1 != d.indexOf("bsd") && (l = "BSD"), -1 != d.indexOf("osf1") && (l = "OSF1"), -1 != d.indexOf("irix") && (l = "IRIX", z = ""), -1 != d.indexOf("freebsd") && (l = "FreeBSD"), -1 != d.indexOf("symbianos") && (l = "SymbianOS", z = d.substring(d.indexOf("SymbianOS/") + 10, 3))
        } catch (a) { }
        var y = "NA",
            n = "NA",
            w = "";
        try {
            -1 != d.indexOf("msie") && (y = "ie", (n = d.substring(d.indexOf("msie ") + 5)).indexOf(";") && (n = n.substring(0, n.indexOf(";")))), -1 != d.indexOf("firefox") && (y = "Firefox", n = d.substring(d.indexOf("firefox/") + 8)), -1 != d.indexOf("opera") && (y = "Opera", n = d.substring(d.indexOf("opera/") + 6, 4)), -1 != d.indexOf("safari") && (y = "safari", n = d.substring(d.indexOf("safari/") + 7)), -1 != d.indexOf("chrome") && (y = "chrome", (n = d.substring(d.indexOf("chrome/") + 7)).indexOf(" ") && (n = n.substring(0, n.indexOf(" ")), "" != (w = n) && w.indexOf(".") && (w = n.substring(0, n.indexOf("."))))), -1 != d.indexOf("navigator") && (y = "navigator", n = d.substring(d.indexOf("navigator/") + 10)), -1 != d.indexOf("applewebkit") && (y = "applewebkit_chrome", (n = d.substring(d.indexOf("applewebkit/") + 12)).indexOf(" ") && (n = n.substring(0, n.indexOf(" ")))), -1 != d.indexOf("sogoumobilebrowser") && (y = "搜狗手机浏览器"), -1 == d.indexOf("ucbrowser") && -1 == d.indexOf("ucweb") || (y = "UC浏览器"), -1 == d.indexOf("qqbrowser") && -1 == d.indexOf("tencenttraveler") || (y = "QQ浏览器"), -1 != d.indexOf("metasr") && (y = "搜狗浏览器"), -1 != d.indexOf("360se") && (y = "360浏览器"), -1 != d.indexOf("the world") && (y = "世界之窗浏览器"), -1 != d.indexOf("maxthon") && (y = "遨游浏览器")
        } catch (a) { }
        var k = function (a) {
            this.options = this.extend(a, {});
            this.nativeForEach = Array.prototype.forEach;
            this.nativeMap = Array.prototype.map
        };
        return k.prototype = {
            extend: function (a, c) {
                if (null == a) return c;
                for (var b in a) null != a[b] && c[b] !== a[b] && (c[b] = a[b]);
                return c
            },
            getData: function () {
                return u
            },
            get: function (a) {
                var c = 1 * n,
                    b = [];
                "ie" == y && 7 <= c ? (b.push(d), b.push(B), u.userAgent = e(d), u.language = B, this.browserRedirect(d)) : (b = this.userAgentKey(b), b = this.languageKey(b));
                b.push(y);
                b.push(n);
                b.push(l);
                b.push(z);
                u.os = l;
                u.osVersion = z;
                u.browser = y;
                u.browserVersion = n;
                b = this.colorDepthKey(b);
                b = this.screenResolutionKey(b);
                b = this.timezoneOffsetKey(b);
                b = this.sessionStorageKey(b);
                b = this.localStorageKey(b);
                b = this.indexedDbKey(b);
                b = this.addBehaviorKey(b);
                b = this.openDatabaseKey(b);
                b = this.cpuClassKey(b);
                b = this.platformKey(b);
                b = this.hardwareConcurrencyKey(b);
                b = this.audioKey(b);
                b = this.doNotTrackKey(b);
                b = this.pluginsKey(b);
                b = this.canvasKey(b);
                c = this.webglKey(b).join("~~~");
                return a(this.x64hash128(c, 31))
            },
            userAgentKey: function (a) {
                return this.options.excludeUserAgent || (a.push(navigator.userAgent), u.userAgent = e(navigator.userAgent), this.browserRedirect(navigator.userAgent)), a
            },
            replaceAll: function (a, c, b) {
                for (; 0 <= a.indexOf(c);) a = a.replace(c, b);
                return a
            },
            browserRedirect: function (a) {
                var c = a.toLowerCase();
                a = "ipad" == c.match(/ipad/i);
                var b = "iphone os" == c.match(/iphone os/i),
                    g = "midp" == c.match(/midp/i),
                    f = "rv:1.2.3.4" == c.match(/rv:1.2.3.4/i),
                    h = "ucweb" == c.match(/ucweb/i),
                    d = "android" == c.match(/android/i),
                    w = "windows ce" == c.match(/windows ce/i);
                c = "windows mobile" == c.match(/windows mobile/i);
                u.origin = a || b || g || f || h || d || w || c ? "mobile" : "pc"
            },
            languageKey: function (a) {
                return this.options.excludeLanguage || (a.push(navigator.language), u.language = this.replaceAll(navigator.language, " ", "_")), a
            },
            colorDepthKey: function (a) {
                return this.options.excludeColorDepth || (a.push(screen.colorDepth), u.colorDepth = screen.colorDepth), a
            },
            screenResolutionKey: function (a) {
                if (!this.options.excludeScreenResolution) {
                    var c = this.getScreenResolution();
                    void 0 !== c && (a.push(c.join("x")), u.screenResolution = c.join("x"))
                }
                return a
            },
            getScreenResolution: function () {
                return this.options.detectScreenOrientation ? screen.height > screen.width ? [screen.height, screen.width] : [screen.width, screen.height] : [screen.height, screen.width]
            },
            timezoneOffsetKey: function (a) {
                return this.options.excludeTimezoneOffset || (a.push((new Date).getTimezoneOffset()), u.timezoneOffset = (new Date).getTimezoneOffset() / 60), a
            },
            sessionStorageKey: function (a) {
                return !this.options.excludeSessionStorage && this.hasSessionStorage() && (a.push("sessionStorageKey"), u.sessionStorage = !0), a
            },
            localStorageKey: function (a) {
                return !this.options.excludeSessionStorage && this.hasLocalStorage() && (a.push("localStorageKey"), u.localStorage = !0), a
            },
            indexedDbKey: function (a) {
                return !this.options.excludeIndexedDB && this.hasIndexedDB() && (a.push("indexedDbKey"), u.indexedDb = !0), a
            },
            addBehaviorKey: function (a) {
                return document.body && !this.options.excludeAddBehavior && document.body.addBehavior ? (a.push("addBehaviorKey"), u.addBehavior = !0) : u.addBehavior = !1, a
            },
            openDatabaseKey: function (a) {
                return !this.options.excludeOpenDatabase && window.openDatabase ? (a.push("openDatabase"), u.openDatabase = !0) : u.openDatabase = !1, a
            },
            cpuClassKey: function (a) {
                return this.options.excludeCpuClass || (u.cpu = this.getNavigatorCpuClass(), a.push(u.cpu)), a
            },
            platformKey: function (a) {
                return u.platform = this.getNavigatorPlatform(), a.push(u.platform), a
            },
            hardwareConcurrencyKey: function (a) {
                var c = this.getHardwareConcurrency();
                return a.push(c), u.ccn = c, a
            },
            audioKey: function (a) {
                var c = !0;
                if ("" != w && !isNaN(w) && 47 > parseInt(w) && (c = !1), c) if (c = window.AudioContext || window.webkitAudioContext) {
                    c = new c;
                    var b = c.sampleRate.toString();
                    a.push(b);
                    u.asr = b;
                    c.close && c.close()
                }
                return a
            },
            doNotTrackKey: function (a) {
                return this.options.excludeDoNotTrack || (u.track = this.getDoNotTrack(), a.push(u.track)), a
            },
            canvasKey: function (a) {
                var c = !0;
                if (use_breakcollect) {
                    var b = _JdJrRiskClientStorage.jdtdstorage_local_storage("cfjrrval"),
                        g = _JdJrRiskClientStorage.jdtdstorage_local_storage("cfvalmdjrr"),
                        f = _JdJrRiskClientStorage.jdtdstorage_local_storage("timecfjrr");
                    try {
                        b && g && f && 864E5 >= (new Date).getTime() - parseInt(f) && e(b) == g && (c = !1, u.canvas = g, _jdfp_canvas_md5 = g, a.push(b))
                    } catch (h) { }
                }
                c && !this.options.excludeCanvas && this.isCanvasSupported() && (c = this.getCanvasFp(), u.canvas = e(c), _jdfp_canvas_md5 = u.canvas, a.push(c), use_breakcollect && (_JdJrRiskClientStorage.jdtdstorage_local_storage("cfjrrval", c), _JdJrRiskClientStorage.jdtdstorage_local_storage("cfvalmdjrr", _jdfp_canvas_md5), _JdJrRiskClientStorage.jdtdstorage_local_storage("timecfjrr", (new Date).getTime())));
                return a
            },
            webglKey: function (a) {
                var c = !0;
                if (use_breakcollect) {
                    var b = _JdJrRiskClientStorage.jdtdstorage_local_storage("jrrwebglv"),
                        g = _JdJrRiskClientStorage.jdtdstorage_local_storage("webglvmdjrr"),
                        f = _JdJrRiskClientStorage.jdtdstorage_local_storage("timejrrwg");
                    try {
                        b && g && f && 864E5 >= (new Date).getTime() - parseInt(f) && e(b) == g && (c = !1, u.webgl = g, _jdfp_webgl_md5 = g, a.push(b))
                    } catch (h) { }
                }
                c && !this.options.excludeWebGL && this.isCanvasSupported() && (c = this.getWebglFp(), a.push(c), u.webglFp = e(c), _jdfp_webgl_md5 = u.webglFp, use_breakcollect && (_JdJrRiskClientStorage.jdtdstorage_local_storage("jrrwebglv", c), _JdJrRiskClientStorage.jdtdstorage_local_storage("webglvmdjrr", _jdfp_webgl_md5), _JdJrRiskClientStorage.jdtdstorage_local_storage("timejrrwg", (new Date).getTime())));
                return a
            },
            pluginsKey: function (a) {
                var c = this.isIE() ? this.getIEPluginsString() : this.getRegularPluginsString();
                a.push(c);
                u.plugins = e(c);
                return a
            },
            getRegularPluginsString: function () {
                return this.map(navigator.plugins, function (a) {
                    var c = this.map(a, function (a) {
                        return [a.type, a.suffixes].join("~")
                    }).join(",");
                    return [a.name, a.description, c].join("::")
                }, this).join(";")
            },
            getIEPluginsString: function () {
                return void 0 !== window.ActiveXObject ? this.map("AcroPDF.PDF;Adodb.Stream;AgControl.AgControl;DevalVRXCtrl.DevalVRXCtrl.1;MacromediaFlashPaper.MacromediaFlashPaper;Msxml2.DOMDocument;Msxml2.XMLHTTP;PDF.PdfCtrl;QuickTime.QuickTime;QuickTimeCheckObject.QuickTimeCheck.1;RealPlayer;RealPlayer.RealPlayer(tm) ActiveX Control (32-bit);RealVideo.RealVideo(tm) ActiveX Control (32-bit);Scripting.Dictionary;SWCtl.SWCtl;Shell.UIHelper;ShockwaveFlash.ShockwaveFlash;Skype.Detection;TDCCtl.TDCCtl;WMPlayer.OCX;rmocx.RealPlayer G2 Control;rmocx.RealPlayer G2 Control.1".split(";"), function (a) {
                    try {
                        return new ActiveXObject(a), a
                    } catch (c) {
                        return null
                    }
                }).join(";") : ""
            },
            hasSessionStorage: function () {
                try {
                    return !!window.sessionStorage
                } catch (a) {
                    return !0
                }
            },
            hasLocalStorage: function () {
                try {
                    return !!window.localStorage
                } catch (a) {
                    return !0
                }
            },
            hasIndexedDB: function () {
                return !!window.indexedDB
            },
            getNavigatorCpuClass: function () {
                return navigator.oscpu || navigator.cpuClass ? navigator.cpuClass : "NA"
            },
            getNavigatorPlatform: function () {
                return navigator.platform ? navigator.platform : "NA"
            },
            getHardwareConcurrency: function () {
                return navigator.hardwareConcurrency ? navigator.hardwareConcurrency : "NA"
            },
            getDoNotTrack: function () {
                return navigator.doNotTrack || navigator.msDoNotTrack ? navigator.doNotTrack || navigator.msDoNotTrack : "NA"
            },
            getCanvasFp: function () {
                var a = [],
                    c = document.createElement("canvas");
                c.width = 2E3;
                c.height = 200;
                c.style.display = "inline";
                var b = c.getContext("2d");
                return b.rect(0, 0, 10, 10), b.rect(2, 2, 6, 6), a.push("cw:" + (!1 === b.isPointInPath(5, 5, "evenodd") ? "yes" : "no")), b.textBaseline = "alphabetic", b.fillStyle = "#f60", b.fillRect(125, 1, 62, 20), b.fillStyle = "#069", b.font = "11pt no-real-font-123", b.fillText("Cwwm aa fjorddbank glbyphs veext qtuiz, 😃", 2, 15), b.fillStyle = "rgba(102, 204, 0, 0.2)", b.font = "18pt Arial", b.fillText("Cwwm aa fjorddbank glbyphs veext qtuiz, 😃", 4, 45), b.globalCompositeOperation = "multiply", b.fillStyle = "rgb(255,0,255)", b.beginPath(), b.arc(50, 50, 50, 0, 2 * Math.PI, !0), b.closePath(), b.fill(), b.fillStyle = "rgb(0,255,255)", b.beginPath(), b.arc(100, 50, 50, 0, 2 * Math.PI, !0), b.closePath(), b.fill(), b.fillStyle = "rgb(255,255,0)", b.beginPath(), b.arc(75, 100, 50, 0, 2 * Math.PI, !0), b.closePath(), b.fill(), b.fillStyle = "rgb(255,0,255)", b.arc(75, 75, 75, 0, 2 * Math.PI, !0), b.arc(75, 75, 25, 0, 2 * Math.PI, !0), b.fill("evenodd"), a.push("cfp:" + c.toDataURL()), a.join("~")
            },
            getWebglFp: function () {
                var a, c = function (b) {
                    return a.clearColor(0, 0, 0, 1), a.enable(a.DEPTH_TEST), a.depthFunc(a.LEQUAL), a.clear(a.COLOR_BUFFER_BIT | a.DEPTH_BUFFER_BIT), "[" + b[0] + ", " + b[1] + "]"
                };
                if (!(a = this.getWebglCanvas())) return null;
                var b = [],
                    g = a.createBuffer();
                a.bindBuffer(a.ARRAY_BUFFER, g);
                var f = new Float32Array([-.2, -.9, 0, .4, -.26, 0, 0, .732134444, 0]);
                a.bufferData(a.ARRAY_BUFFER, f, a.STATIC_DRAW);
                g.itemSize = 3;
                g.numItems = 3;
                f = a.createProgram();
                var h = a.createShader(a.VERTEX_SHADER);
                a.shaderSource(h, "attribute vec2 attrVertex;varying vec2 varyinTexCoordinate;uniform vec2 uniformOffset;void main(){varyinTexCoordinate=attrVertex+uniformOffset;gl_Position=vec4(attrVertex,0,1);}");
                a.compileShader(h);
                var d = a.createShader(a.FRAGMENT_SHADER);
                a.shaderSource(d, "precision mediump float;varying vec2 varyinTexCoordinate;void main() {gl_FragColor=vec4(varyinTexCoordinate,0,1);}");
                a.compileShader(d);
                a.attachShader(f, h);
                a.attachShader(f, d);
                a.linkProgram(f);
                a.useProgram(f);
                f.vertexPosAttrib = a.getAttribLocation(f, "attrVertex");
                f.offsetUniform = a.getUniformLocation(f, "uniformOffset");
                a.enableVertexAttribArray(f.vertexPosArray);
                a.vertexAttribPointer(f.vertexPosAttrib, g.itemSize, a.FLOAT, !1, 0, 0);
                a.uniform2f(f.offsetUniform, 1, 1);
                a.drawArrays(a.TRIANGLE_STRIP, 0, g.numItems);
                null != a.canvas && b.push(a.canvas.toDataURL());
                b.push("extensions:" + a.getSupportedExtensions().join(";"));
                b.push("w1" + c(a.getParameter(a.ALIASED_LINE_WIDTH_RANGE)));
                b.push("w2" + c(a.getParameter(a.ALIASED_POINT_SIZE_RANGE)));
                b.push("w3" + a.getParameter(a.ALPHA_BITS));
                b.push("w4" + (a.getContextAttributes().antialias ? "yes" : "no"));
                b.push("w5" + a.getParameter(a.BLUE_BITS));
                b.push("w6" + a.getParameter(a.DEPTH_BITS));
                b.push("w7" + a.getParameter(a.GREEN_BITS));
                b.push("w8" +
                    function (a) {
                        var b, c = a.getExtension("EXT_texture_filter_anisotropic") || a.getExtension("WEBKIT_EXT_texture_filter_anisotropic") || a.getExtension("MOZ_EXT_texture_filter_anisotropic");
                        return c ? (0 === (b = a.getParameter(c.MAX_TEXTURE_MAX_ANISOTROPY_EXT)) && (b = 2), b) : null
                    }(a));
                b.push("w9" + a.getParameter(a.MAX_COMBINED_TEXTURE_IMAGE_UNITS));
                b.push("w10" + a.getParameter(a.MAX_CUBE_MAP_TEXTURE_SIZE));
                b.push("w11" + a.getParameter(a.MAX_FRAGMENT_UNIFORM_VECTORS));
                b.push("w12" + a.getParameter(a.MAX_RENDERBUFFER_SIZE));
                b.push("w13" + a.getParameter(a.MAX_TEXTURE_IMAGE_UNITS));
                b.push("w14" + a.getParameter(a.MAX_TEXTURE_SIZE));
                b.push("w15" + a.getParameter(a.MAX_VARYING_VECTORS));
                b.push("w16" + a.getParameter(a.MAX_VERTEX_ATTRIBS));
                b.push("w17" + a.getParameter(a.MAX_VERTEX_TEXTURE_IMAGE_UNITS));
                b.push("w18" + a.getParameter(a.MAX_VERTEX_UNIFORM_VECTORS));
                b.push("w19" + c(a.getParameter(a.MAX_VIEWPORT_DIMS)));
                b.push("w20" + a.getParameter(a.RED_BITS));
                b.push("w21" + a.getParameter(a.RENDERER));
                b.push("w22" + a.getParameter(a.SHADING_LANGUAGE_VERSION));
                b.push("w23" + a.getParameter(a.STENCIL_BITS));
                b.push("w24" + a.getParameter(a.VENDOR));
                b.push("w25" + a.getParameter(a.VERSION));
                try {
                    var w = a.getExtension("WEBGL_debug_renderer_info");
                    w && (b.push("wuv:" + a.getParameter(w.UNMASKED_VENDOR_WEBGL)), b.push("wur:" + a.getParameter(w.UNMASKED_RENDERER_WEBGL)))
                } catch (D) { }
                return a.getShaderPrecisionFormat ? (b.push("w26" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.HIGH_FLOAT).precision), b.push("w27" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.HIGH_FLOAT).rangeMin), b.push("w28" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.HIGH_FLOAT).rangeMax), b.push("w29" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.MEDIUM_FLOAT).precision), b.push("w30" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.MEDIUM_FLOAT).rangeMin), b.push("w31" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.MEDIUM_FLOAT).rangeMax), b.push("w32" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.LOW_FLOAT).precision), b.push("w33" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.LOW_FLOAT).rangeMin), b.push("w34" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.LOW_FLOAT).rangeMax), b.push("w35" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.HIGH_FLOAT).precision), b.push("w36" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.HIGH_FLOAT).rangeMin), b.push("w37" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.HIGH_FLOAT).rangeMax), b.push("w38" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.MEDIUM_FLOAT).precision), b.push("w39" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.MEDIUM_FLOAT).rangeMin), b.push("w40" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.MEDIUM_FLOAT).rangeMax), b.push("w41" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.LOW_FLOAT).precision), b.push("w42" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.LOW_FLOAT).rangeMin), b.push("w43" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.LOW_FLOAT).rangeMax), b.push("w44" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.HIGH_INT).precision), b.push("w45" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.HIGH_INT).rangeMin), b.push("w46" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.HIGH_INT).rangeMax), b.push("w47" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.MEDIUM_INT).precision), b.push("w48" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.MEDIUM_INT).rangeMin), b.push("w49" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.MEDIUM_INT).rangeMax), b.push("w50" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.LOW_INT).precision), b.push("w51" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.LOW_INT).rangeMin), b.push("w52" + a.getShaderPrecisionFormat(a.VERTEX_SHADER, a.LOW_INT).rangeMax), b.push("w53" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.HIGH_INT).precision), b.push("w54" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.HIGH_INT).rangeMin), b.push("w55" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.HIGH_INT).rangeMax), b.push("w56" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.MEDIUM_INT).precision), b.push("w57" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.MEDIUM_INT).rangeMin), b.push("w58" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.MEDIUM_INT).rangeMax), b.push("w59" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.LOW_INT).precision), b.push("w60" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.LOW_INT).rangeMin), b.push("w61" + a.getShaderPrecisionFormat(a.FRAGMENT_SHADER, a.LOW_INT).rangeMax), b.join("§")) : b.join("§")
            },
            isCanvasSupported: function () {
                var a = document.createElement("canvas");
                return !(!a.getContext || !a.getContext("2d"))
            },
            isIE: function () {
                return "Microsoft Internet Explorer" === navigator.appName || !("Netscape" !== navigator.appName || !/Trident/.test(navigator.userAgent))
            },
            getWebglCanvas: function () {
                var a = document.createElement("canvas"),
                    c = null;
                try {
                    c = a.getContext("webgl") || a.getContext("experimental-webgl")
                } catch (b) { }
                return c || (c = null), c
            },
            each: function (a, c, b) {
                if (null !== a) if (this.nativeForEach && a.forEach === this.nativeForEach) a.forEach(c, b);
                else if (a.length === +a.length) for (var g = 0, f = a.length; g < f && c.call(b, a[g], g, a) !== {}; g++);
                else for (g in a) if (a.hasOwnProperty(g) && c.call(b, a[g], g, a) === {}) break
            },
            map: function (a, c, b) {
                var g = [];
                return null == a ? g : this.nativeMap && a.map === this.nativeMap ? a.map(c, b) : (this.each(a, function (a, h, d) {
                    g[g.length] = c.call(b, a, h, d)
                }), g)
            },
            x64Add: function (a, c) {
                a = [a[0] >>> 16, 65535 & a[0], a[1] >>> 16, 65535 & a[1]];
                c = [c[0] >>> 16, 65535 & c[0], c[1] >>> 16, 65535 & c[1]];
                var b = [0, 0, 0, 0];
                return b[3] += a[3] + c[3], b[2] += b[3] >>> 16, b[3] &= 65535, b[2] += a[2] + c[2], b[1] += b[2] >>> 16, b[2] &= 65535, b[1] += a[1] + c[1], b[0] += b[1] >>> 16, b[1] &= 65535, b[0] += a[0] + c[0], b[0] &= 65535, [b[0] << 16 | b[1], b[2] << 16 | b[3]]
            },
            x64Multiply: function (a, c) {
                a = [a[0] >>> 16, 65535 & a[0], a[1] >>> 16, 65535 & a[1]];
                c = [c[0] >>> 16, 65535 & c[0], c[1] >>> 16, 65535 & c[1]];
                var b = [0, 0, 0, 0];
                return b[3] += a[3] * c[3], b[2] += b[3] >>> 16, b[3] &= 65535, b[2] += a[2] * c[3], b[1] += b[2] >>> 16, b[2] &= 65535, b[2] += a[3] * c[2], b[1] += b[2] >>> 16, b[2] &= 65535, b[1] += a[1] * c[3], b[0] += b[1] >>> 16, b[1] &= 65535, b[1] += a[2] * c[2], b[0] += b[1] >>> 16, b[1] &= 65535, b[1] += a[3] * c[1], b[0] += b[1] >>> 16, b[1] &= 65535, b[0] += a[0] * c[3] + a[1] * c[2] + a[2] * c[1] + a[3] * c[0], b[0] &= 65535, [b[0] << 16 | b[1], b[2] << 16 | b[3]]
            },
            x64Rotl: function (a, c) {
                return c %= 64, 32 === c ? [a[1], a[0]] : 32 > c ? [a[0] << c | a[1] >>> 32 - c, a[1] << c | a[0] >>> 32 - c] : (c -= 32, [a[1] << c | a[0] >>> 32 - c, a[0] << c | a[1] >>> 32 - c])
            },
            x64LeftShift: function (a, c) {
                return c %= 64, 0 === c ? a : 32 > c ? [a[0] << c | a[1] >>> 32 - c, a[1] << c] : [a[1] << c - 32, 0]
            },
            x64Xor: function (a, c) {
                return [a[0] ^ c[0], a[1] ^ c[1]]
            },
            x64Fmix: function (a) {
                return a = this.x64Xor(a, [0, a[0] >>> 1]), a = this.x64Multiply(a, [4283543511, 3981806797]), a = this.x64Xor(a, [0, a[0] >>> 1]), a = this.x64Multiply(a, [3301882366, 444984403]), this.x64Xor(a, [0, a[0] >>> 1])
            },
            x64hash128: function (a, c) {
                a = a || "";
                c = c || 0;
                var b = a.length % 16,
                    g = a.length - b,
                    f = [0, c];
                c = [0, c];
                for (var h, d, w = [2277735313, 289559509], l = [1291169091, 658871167], k = 0; k < g; k += 16) h = [255 & a.charCodeAt(k + 4) | (255 & a.charCodeAt(k + 5)) << 8 | (255 & a.charCodeAt(k + 6)) << 16 | (255 & a.charCodeAt(k + 7)) << 24, 255 & a.charCodeAt(k) | (255 & a.charCodeAt(k + 1)) << 8 | (255 & a.charCodeAt(k + 2)) << 16 | (255 & a.charCodeAt(k + 3)) << 24], d = [255 & a.charCodeAt(k + 12) | (255 & a.charCodeAt(k + 13)) << 8 | (255 & a.charCodeAt(k + 14)) << 16 | (255 & a.charCodeAt(k + 15)) << 24, 255 & a.charCodeAt(k + 8) | (255 & a.charCodeAt(k + 9)) << 8 | (255 & a.charCodeAt(k + 10)) << 16 | (255 & a.charCodeAt(k + 11)) << 24], h = this.x64Multiply(h, w), h = this.x64Rotl(h, 31), h = this.x64Multiply(h, l), f = this.x64Xor(f, h), f = this.x64Rotl(f, 27), f = this.x64Add(f, c), f = this.x64Add(this.x64Multiply(f, [0, 5]), [0, 1390208809]), d = this.x64Multiply(d, l), d = this.x64Rotl(d, 33), d = this.x64Multiply(d, w), c = this.x64Xor(c, d), c = this.x64Rotl(c, 31), c = this.x64Add(c, f), c = this.x64Add(this.x64Multiply(c, [0, 5]), [0, 944331445]);
                switch (h = [0, 0], d = [0, 0], b) {
                    case 15:
                        d = this.x64Xor(d, this.x64LeftShift([0, a.charCodeAt(k + 14)], 48));
                    case 14:
                        d = this.x64Xor(d, this.x64LeftShift([0, a.charCodeAt(k + 13)], 40));
                    case 13:
                        d = this.x64Xor(d, this.x64LeftShift([0, a.charCodeAt(k + 12)], 32));
                    case 12:
                        d = this.x64Xor(d, this.x64LeftShift([0, a.charCodeAt(k + 11)], 24));
                    case 11:
                        d = this.x64Xor(d, this.x64LeftShift([0, a.charCodeAt(k + 10)], 16));
                    case 10:
                        d = this.x64Xor(d, this.x64LeftShift([0, a.charCodeAt(k + 9)], 8));
                    case 9:
                        d = this.x64Xor(d, [0, a.charCodeAt(k + 8)]), d = this.x64Multiply(d, l), d = this.x64Rotl(d, 33), d = this.x64Multiply(d, w), c = this.x64Xor(c, d);
                    case 8:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 7)], 56));
                    case 7:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 6)], 48));
                    case 6:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 5)], 40));
                    case 5:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 4)], 32));
                    case 4:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 3)], 24));
                    case 3:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 2)], 16));
                    case 2:
                        h = this.x64Xor(h, this.x64LeftShift([0, a.charCodeAt(k + 1)], 8));
                    case 1:
                        h = this.x64Xor(h, [0, a.charCodeAt(k)]), h = this.x64Multiply(h, w), h = this.x64Rotl(h, 31), h = this.x64Multiply(h, l), f = this.x64Xor(f, h)
                }
                return f = this.x64Xor(f, [0, a.length]), c = this.x64Xor(c, [0, a.length]), f = this.x64Add(f, c), c = this.x64Add(c, f), f = this.x64Fmix(f), c = this.x64Fmix(c), f = this.x64Add(f, c), c = this.x64Add(c, f), ("00000000" + (f[0] >>> 0).toString(16)).slice(-8) + ("00000000" + (f[1] >>> 0).toString(16)).slice(-8) + ("00000000" + (c[0] >>> 0).toString(16)).slice(-8) + ("00000000" + (c[1] >>> 0).toString(16)).slice(-8)
            }
        }, k
    });
    try {
        !
            function (e) {
                var m = e.document,
                    q = (e.Image, e.globalStorage);
                try {
                    var v = e.localStorage
                } catch (A) { }
                try {
                    var x = e.sessionStorage
                } catch (A) { }
                var t = {
                    history: !0,
                    java: !1,
                    tests: 5,
                    silverlight: !1,
                    domain: ".jd.com",
                    baseurl: _CurrentPageProtocol + _JdJrTdRiskDomainName,
                    asseturi: ""
                };
                e.JDJRTDLOCALSTORAGE = function (A) {
                    A = A || {};
                    var p = {},
                        r;
                    for (r in t) {
                        var u = A[r];
                        p[r] = void 0 !== u ? u : t[r]
                    }
                    "function" == typeof p.domain && (p.domain = p.domain(e));
                    p.history;
                    p.java;
                    var d = p.tests,
                        B = (p.baseurl, p.asseturi, p.domain),
                        l = this;
                    this._ec = {};
                    this.get = function (d, k, a) {
                        l._jdtdstorage(d, k, void 0, void 0, a)
                    };
                    this.set = function (d, k) {
                        l._jdtdstorage(d, function () { }, k)
                    };
                    this._jdtdstorage = function (w, k, a, c, b) {
                        if (void 0 === l._jdtdstorage && (l = this), void 0 === c && (c = 1), 1 === c && (l.jdtdstorage_database_storage(w, a), l.jdtdstorage_indexdb_storage(w, a), l._ec.userData = l.jdtdstorage_userdata(w, a), l._ec.cookieData = l.jdtdstorage_cookie(w, a), l._ec.localData = l.jdtdstorage_local_storage(w, a), l._ec.globalData = l.jdtdstorage_global_storage(w, a), l._ec.sessionData = l.jdtdstorage_session_storage(w, a), l._ec.windowData = l.jdtdstorage_window(w, a)), void 0 == a) if ((!("undefined" !== l._ec.userData && l._ec.userData || "undefined" !== l._ec.cookieData && l._ec.cookieData || "undefined" !== l._ec.localData && l._ec.localData || "undefined" !== l._ec.globalData && l._ec.globalData || "undefined" !== l._ec.sessionData && l._ec.sessionData || "undefined" !== l._ec.dbData && l._ec.dbData || "undefined" !== l._ec.idbData && l._ec.idbData) && e.openDatabase && void 0 === l._ec.dbData || ("indexedDB" in e || (e.indexedDB = e.indexedDB || e.mozIndexedDB || e.webkitIndexedDB || e.msIndexedDB)) && (void 0 === l._ec.idbData || "" === l._ec.idbData)) && c++ < d) setTimeout(function () {
                            l._jdtdstorage(w, k, a, c, b)
                        }, 30);
                        else {
                            var g, f, h = l._ec,
                                n = [],
                                r = 0;
                            l._ec = {};
                            for (f in h) h[f] && "null" !== h[f] && "undefined" !== h[f] && (n[h[f]] = void 0 === n[h[f]] ? 1 : n[h[f]] + 1);
                            for (f in n) n[f] > r && (r = n[f], g = f);
                            void 0 === g || void 0 !== b && 1 === b || l.set(w, g);
                            "function" == typeof k && k(g, h)
                        }
                    };
                    this.jdtdstorage_window = function (d, k) {
                        try {
                            if (void 0 === k) return this.getFromStr(d, e.name);
                            var a = e.name;
                            if (-1 < a.indexOf("&" + d + "=") || 0 === a.indexOf(d + "=")) {
                                var c, b = a.indexOf("&" + d + "=");
                                var g = (-1 === b && (b = a.indexOf(d + "=")), c = a.indexOf("&", b + 1), -1 !== c ? a.substr(0, b) + a.substr(c + (b ? 0 : 1)) + "&" + d + "=" + k : a.substr(0, b) + "&" + d + "=" + k)
                            } else g = a + "&" + d + "=" + k;
                            e.name = g
                        } catch (f) { }
                    };
                    this.jdtdstorage_userdata = function (d, k) {
                        try {
                            var a = this.createElem("div", "userdata_el", 1);
                            if (a.addBehavior) {
                                if (d = d.substring(1), a.style.behavior = "url(#default#userData)", void 0 === k) return a.load(d), a.getAttribute(d);
                                a.setAttribute(d, k);
                                a.save(d)
                            }
                        } catch (c) { }
                    };
                    this.jdtdstorage_lso = function (d, k) { };
                    this.jdtdstorage_png = function (d, k) { };
                    this.jdtdstorage_local_storage = function (d, k) {
                        try {
                            if (v) {
                                if (void 0 === k) return v.getItem(d);
                                v.setItem(d, k)
                            }
                        } catch (a) { }
                    };
                    this.jdtdstorage_database_storage = function (d, k) {
                        try {
                            if (e.openDatabase) {
                                var a = e.openDatabase("sqlite_jdtdstorage", "", "jdtdstorage", 1048576);
                                void 0 !== k ? a.transaction(function (a) {
                                    a.executeSql("CREATE TABLE IF NOT EXISTS cache(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL, value TEXT NOT NULL, UNIQUE (name))", [], function (a, c) { }, function (a, c) { });
                                    a.executeSql("INSERT OR REPLACE INTO cache(name, value) VALUES(?, ?)", [d, k], function (a, c) { }, function (a, c) { })
                                }) : a.transaction(function (a) {
                                    a.executeSql("SELECT value FROM cache WHERE name=?", [d], function (a, c) {
                                        1 <= c.rows.length ? l._ec.dbData = c.rows.item(0).value : l._ec.dbData = ""
                                    }, function (a, c) { })
                                })
                            }
                        } catch (c) { }
                    };
                    this.jdtdstorage_indexdb_storage = function (d, k) {
                        try {
                            var a = e.indexedDB || e.mozIndexedDB || e.webkitIndexedDB || e.msIndexedDB;
                            e.IDBTransaction || e.webkitIDBTransaction || e.msIDBTransaction;
                            e.IDBKeyRange || e.webkitIDBKeyRange || e.msIDBKeyRange;
                            if (a) {
                                var c = a.open("idb_jdtdstorage", 1);
                                c.onerror = function (a) { };
                                c.onupgradeneeded = function () {
                                    c.result.createObjectStore("jdtdstorage", {
                                        keyPath: "name"
                                    })
                                };
                                c.onsuccess = function () {
                                    var a = c.result,
                                        g = a.transaction(["jdtdstorage"], "readwrite"),
                                        f = g.objectStore(["jdtdstorage"]);
                                    if (void 0 !== k) f.put({
                                        name: d,
                                        value: k
                                    });
                                    else {
                                        var h = f.get(d);
                                        h.onsuccess = function () {
                                            void 0 === h.result ? l._ec.idbData = void 0 : l._ec.idbData = h.result.value
                                        }
                                    }
                                    g.oncomplete = function () {
                                        a.close()
                                    }
                                }
                            }
                        } catch (b) { }
                    };
                    this.jdtdstorage_session_storage = function (d, k) {
                        try {
                            if (x) {
                                if (void 0 === k) return x.getItem(d);
                                x.setItem(d, k)
                            }
                        } catch (a) { }
                    };
                    this.jdtdstorage_global_storage = function (d, k) {
                        if (q) {
                            var a = this.getHost();
                            try {
                                if (void 0 === k) return q[a][d];
                                q[a][d] = k
                            } catch (c) { }
                        }
                    };
                    this.jdtdstorage_silverlight = function (d, k) { };
                    this.encode = function (d) {
                        var k, a, c = "",
                            b = 0;
                        for (d = this._utf8_encode(d); b < d.length;) {
                            var g = (k = d.charCodeAt(b++)) >> 2;
                            var f = (3 & k) << 4 | (k = d.charCodeAt(b++)) >> 4;
                            var h = (15 & k) << 2 | (a = d.charCodeAt(b++)) >> 6;
                            var l = 63 & a;
                            isNaN(k) ? h = l = 64 : isNaN(a) && (l = 64);
                            c = c + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".charAt(g) + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".charAt(f) + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".charAt(h) + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".charAt(l)
                        }
                        return c
                    };
                    this.decode = function (d) {
                        var k, a, c, b = "",
                            g = 0;
                        for (d = d.replace(/[^A-Za-z0-9\+\/=]/g, ""); g < d.length;) {
                            var f = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".indexOf(d.charAt(g++)) << 2 | (k = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".indexOf(d.charAt(g++))) >> 4;
                            k = (15 & k) << 4 | (a = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".indexOf(d.charAt(g++))) >> 2;
                            var h = (3 & a) << 6 | (c = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".indexOf(d.charAt(g++)));
                            b += String.fromCharCode(f);
                            64 !== a && (b += String.fromCharCode(k));
                            64 !== c && (b += String.fromCharCode(h))
                        }
                        return this._utf8_decode(b)
                    };
                    this._utf8_encode = function (d) {
                        for (var k, a = "", c = 0, b = (d = d.replace(/\r\n/g, "\n")).length; c < b; c++) 128 > (k = d.charCodeAt(c)) ? a += String.fromCharCode(k) : 127 < k && 2048 > k ? (a += String.fromCharCode(k >> 6 | 192), a += String.fromCharCode(63 & k | 128)) : (a += String.fromCharCode(k >> 12 | 224), a += String.fromCharCode(k >> 6 & 63 | 128), a += String.fromCharCode(63 & k | 128));
                        return a
                    };
                    this._utf8_decode = function (d) {
                        for (var k = "", a = 0, c = d.length, b = 0, g = 0, f = 0; a < c;) 128 > (b = d.charCodeAt(a)) ? (k += String.fromCharCode(b), a += 1) : 191 < b && 224 > b ? (g = d.charCodeAt(a + 1), k += String.fromCharCode((31 & b) << 6 | 63 & g), a += 2) : (g = d.charCodeAt(a + 1), f = d.charCodeAt(a + 2), k += String.fromCharCode((15 & b) << 12 | (63 & g) << 6 | 63 & f), a += 3);
                        return k
                    };
                    this.jdtdstorage_history = function (d, k) { };
                    this.createElem = function (d, k, a) {
                        var c;
                        return c = void 0 !== k && m.getElementById(k) ? m.getElementById(k) : m.createElement(d), c.style.visibility = "hidden", c.style.position = "absolute", k && c.setAttribute("id", k), a && m.body.appendChild(c), c
                    };
                    this.createIframe = function (d, k) {
                        k = this.createElem("iframe", k, 1);
                        return k.setAttribute("src", d), k
                    };
                    this.jdtdstorage_cookie = function (d, k) {
                        if (void 0 === k) return this.getFromStr(d, m.cookie);
                        m.cookie = d + "=" + k + "; expires=Tue, 31 Dec 2030 00:00:00 UTC; path=/; domain=" + B
                    };
                    this.getFromStr = function (d, k) {
                        if ("string" == typeof k) {
                            var a;
                            d += "=";
                            var c = k.split(/[;&]/);
                            for (k = 0; k < c.length; k++) {
                                for (a = c[k];
                                    " " === a.charAt(0);) a = a.substring(1, a.length);
                                if (0 === a.indexOf(d)) return a.substring(d.length, a.length)
                            }
                        }
                    };
                    this.getHost = function () {
                        return e.location.host.replace(/:\d+/, "")
                    };
                    this.toHex = function (d) {
                        for (var k, a = "", c = d.length, b = 0; b < c;) {
                            for (k = d.charCodeAt(b++).toString(16); 2 > k.length;) k = "0" + k;
                            a += k
                        }
                        return a
                    };
                    this.fromHex = function (d) {
                        for (var k, a = "", c = d.length; 0 <= c;) k = c - 2, a = String.fromCharCode("0x" + d.substring(k, c)) + a, c = k;
                        return a
                    };
                    this.hasVisited = function (d) { };
                    var z, y = this.createElem("a", "_ec_rgb_link");
                    try {
                        var n = 1;
                        (z = m.createElement("style")).styleSheet ? z.styleSheet.innerHTML = "#_ec_rgb_link:visited{display:none;color:#FF0000}" : z.innerHTML ? z.innerHTML = "#_ec_rgb_link:visited{display:none;color:#FF0000}" : z.appendChild(m.createTextNode("#_ec_rgb_link:visited{display:none;color:#FF0000}"))
                    } catch (w) {
                        n = 0
                    }
                    this._getRGB = function (d, k) {
                        if (k && 0 === n) return -1;
                        y.href = d;
                        y.innerHTML = d;
                        m.body.appendChild(z);
                        m.body.appendChild(y);
                        if (m.defaultView) {
                            if (null == m.defaultView.getComputedStyle(y, null)) return -1;
                            d = m.defaultView.getComputedStyle(y, null).getPropertyValue("color")
                        } else d = y.currentStyle.color;
                        return d
                    };
                    this._testURL = function (d, k) {
                        d = this._getRGB(d);
                        return "rgb(255, 0, 0)" === d || "#ff0000" === d ? 1 : k && d !== k ? 1 : 0
                    }
                }
            }(window)
    } catch (e) { }
    var td_collect = new function () {
        function e() {
            var e = window.webkitRTCPeerConnection || window.mozRTCPeerConnection || window.RTCPeerConnection;
            if (e) {
                var r = function (d) {
                    var l = /([0-9]{1,3}(\.[0-9]{1,3}){3})/;
                    try {
                        var e = l.exec(d)[1];
                        void 0 === m[e] && v.push(e);
                        m[e] = !0
                    } catch (y) { }
                },
                    m = {};
                try {
                    var d = new e({
                        iceServers: [{
                            urls: "stun:stun.services.mozilla.com"
                        }]
                    })
                } catch (B) { }
                try {
                    void 0 === d && (d = new e({
                        iceServers: []
                    }))
                } catch (B) { }
                if (d || window.mozRTCPeerConnection) try {
                    d.createDataChannel("chat", {
                        reliable: !1
                    })
                } catch (B) { }
                d && (d.onicecandidate = function (d) {
                    d.candidate && r(d.candidate.candidate)
                }, d.createOffer(function (e) {
                    d.setLocalDescription(e, function () { }, function () { })
                }, function () { }), setTimeout(function () {
                    try {
                        d.localDescription.sdp.split("\n").forEach(function (d) {
                            0 === d.indexOf("a=candidate:") && r(d)
                        })
                    } catch (B) { }
                }, 500))
            }
            try {
                navigator.mediaDevices && navigator.mediaDevices.enumerateDevices().then(function (d) {
                    var l = [];
                    d.forEach(function (d) {
                        l.push(d.kind + ";" + d.label + ";" + d.deviceId)
                    });
                    x = l.sort().join("|")
                })
            } catch (B) { }
        }
        function m() {
            function e(l) {
                var e = {};
                return d.style.fontFamily = l, document.body.appendChild(d), e.height = d.offsetHeight, e.width = d.offsetWidth, document.body.removeChild(d), e
            }
            var r = ["monospace", "sans-serif", "serif"],
                m = [],
                d = document.createElement("span");
            d.style.fontSize = "72px";
            d.style.visibility = "hidden";
            d.innerHTML = "mmmmmmmmmmlli";
            for (var B = 0; B < r.length; B++) m[B] = e(r[B]);
            this.checkSupportFont = function (d) {
                for (var l = 0; l < m.length; l++) {
                    var p = e(d + "," + r[l]),
                        n = m[l];
                    if (p.height !== n.height || p.width !== n.width) return !0
                }
                return !1
            }
        }
        function q(e) {
            var r = {};
            r.name = e.name;
            r.filename = e.filename.toLowerCase();
            r.description = e.description;
            void 0 !== e.version && (r.version = e.version);
            r.mimeTypes = [];
            for (var m = 0; m < e.length; m++) {
                var d = e[m],
                    p = {};
                p.description = d.description;
                p.suffixes = d.suffixes;
                p.type = d.type;
                r.mimeTypes.push(p)
            }
            return r
        }
        var v = [],
            x = "",
            t = "Abadi MT Condensed Light;Adobe Fangsong Std;Adobe Hebrew;Adobe Ming Std;Agency FB;Arab;Arabic Typesetting;Arial Black;Batang;Bauhaus 93;Bell MT;Bitstream Vera Serif;Bodoni MT;Bookman Old Style;Braggadocio;Broadway;Calibri;Californian FB;Castellar;Casual;Centaur;Century Gothic;Chalkduster;Colonna MT;Copperplate Gothic Light;DejaVu LGC Sans Mono;Desdemona;DFKai-SB;Dotum;Engravers MT;Eras Bold ITC;Eurostile;FangSong;Forte;Franklin Gothic Heavy;French Script MT;Gabriola;Gigi;Gisha;Goudy Old Style;Gulim;GungSeo;Haettenschweiler;Harrington;Hiragino Sans GB;Impact;Informal Roman;KacstOne;Kino MT;Kozuka Gothic Pr6N;Lohit Gujarati;Loma;Lucida Bright;Lucida Fax;Magneto;Malgun Gothic;Matura MT Script Capitals;Menlo;MingLiU-ExtB;MoolBoran;MS PMincho;MS Reference Sans Serif;News Gothic MT;Niagara Solid;Nyala;Palace Script MT;Papyrus;Perpetua;Playbill;PMingLiU;Rachana;Rockwell;Sawasdee;Script MT Bold;Segoe Print;Showcard Gothic;SimHei;Snap ITC;TlwgMono;Tw Cen MT Condensed Extra Bold;Ubuntu;Umpush;Univers;Utopia;Vladimir Script;Wide Latin".split(";"),
            A = "4game;AdblockPlugin;AdobeExManCCDetect;AdobeExManDetect;Alawar NPAPI utils;Aliedit Plug-In;Alipay Security Control 3;AliSSOLogin plugin;AmazonMP3DownloaderPlugin;AOL Media Playback Plugin;AppUp;ArchiCAD;AVG SiteSafety plugin;Babylon ToolBar;Battlelog Game Launcher;BitCometAgent;Bitdefender QuickScan;BlueStacks Install Detector;CatalinaGroup Update;Citrix ICA Client;Citrix online plug-in;Citrix Receiver Plug-in;Coowon Update;DealPlyLive Update;Default Browser Helper;DivX Browser Plug-In;DivX Plus Web Player;DivX VOD Helper Plug-in;doubleTwist Web Plugin;Downloaders plugin;downloadUpdater;eMusicPlugin DLM6;ESN Launch Mozilla Plugin;ESN Sonar API;Exif Everywhere;Facebook Plugin;File Downloader Plug-in;FileLab plugin;FlyOrDie Games Plugin;Folx 3 Browser Plugin;FUZEShare;GDL Object Web Plug-in 16.00;GFACE Plugin;Ginger;Gnome Shell Integration;Google Earth Plugin;Google Earth Plug-in;Google Gears 0.5.33.0;Google Talk Effects Plugin;Google Update;Harmony Firefox Plugin;Harmony Plug-In;Heroes & Generals live;HPDetect;Html5 location provider;IE Tab plugin;iGetterScriptablePlugin;iMesh plugin;Kaspersky Password Manager;LastPass;LogMeIn Plugin 1.0.0.935;LogMeIn Plugin 1.0.0.961;Ma-Config.com plugin;Microsoft Office 2013;MinibarPlugin;Native Client;Nitro PDF Plug-In;Nokia Suite Enabler Plugin;Norton Identity Safe;npAPI Plugin;NPLastPass;NPPlayerShell;npTongbuAddin;NyxLauncher;Octoshape Streaming Services;Online Storage plug-in;Orbit Downloader;Pando Web Plugin;Parom.TV player plugin;PDF integrado do WebKit;PDF-XChange Viewer;PhotoCenterPlugin1.1.2.2;Picasa;PlayOn Plug-in;QQ2013 Firefox Plugin;QQDownload Plugin;QQMiniDL Plugin;QQMusic;RealDownloader Plugin;Roblox Launcher Plugin;RockMelt Update;Safer Update;SafeSearch;Scripting.Dictionary;SefClient Plugin;Shell.UIHelper;Silverlight Plug-In;Simple Pass;Skype Web Plugin;SumatraPDF Browser Plugin;Symantec PKI Client;Tencent FTN plug-in;Thunder DapCtrl NPAPI Plugin;TorchHelper;Unity Player;Uplay PC;VDownloader;Veetle TV Core;VLC Multimedia Plugin;Web Components;WebKit-integrierte PDF;WEBZEN Browser Extension;Wolfram Mathematica;WordCaptureX;WPI Detector 1.4;Yandex Media Plugin;Yandex PDF Viewer;YouTube Plug-in;zako".split(";");
        this.toJson = "object" == typeof JSON && JSON.stringify;
        this.init = function () {
            e();
            "function" != typeof this.toJson && (this.toJson = function (e) {
                if (void 0 == e || null == e) return null;
                var m = "{",
                    p;
                for (p in e) m += "'" + p + "':", "string" == typeof e[p] ? m += "'" + e[p] + "'" : m += e[p], m += ",";
                return m = m.substring(0, m.length - 1), m + "}"
            })
        };
        this.minHash = function (e) {
            var m, q = 3 & e.length,
                d = e.length - q;
            var p = void 0;
            for (m = 0; m < d;) {
                var l = 255 & e.charCodeAt(m) | (255 & e.charCodeAt(++m)) << 8 | (255 & e.charCodeAt(++m)) << 16 | (255 & e.charCodeAt(++m)) << 24;
                ++m;
                l = 3432918353 * (65535 & l) + ((3432918353 * (l >>> 16) & 65535) << 16) & 4294967295;
                l = l << 15 | l >>> 17;
                l = 461845907 * (65535 & l) + ((461845907 * (l >>> 16) & 65535) << 16) & 4294967295;
                p ^= l;
                p = p << 13 | p >>> 19;
                p = 5 * (65535 & p) + ((5 * (p >>> 16) & 65535) << 16) & 4294967295;
                p = 27492 + (65535 & p) + ((58964 + (p >>> 16) & 65535) << 16)
            }
            switch (l = 0, q) {
                case 3:
                    l ^= (255 & e.charCodeAt(m + 2)) << 16;
                case 2:
                    l ^= (255 & e.charCodeAt(m + 1)) << 8;
                case 1:
                    p ^= 461845907 * (65535 & (l = (l = 3432918353 * (65535 & (l ^= 255 & e.charCodeAt(m))) + ((3432918353 * (l >>> 16) & 65535) << 16) & 4294967295) << 15 | l >>> 17)) + ((461845907 * (l >>> 16) & 65535) << 16) & 4294967295
            }
            return p ^= e.length, p ^= p >>> 16, p = 2246822507 * (65535 & p) + ((2246822507 * (p >>> 16) & 65535) << 16) & 4294967295, p ^= p >>> 13, p = 3266489909 * (65535 & p) + ((3266489909 * (p >>> 16) & 65535) << 16) & 4294967295, (p ^ p >>> 16) >>> 0
        };
        this.tdencrypt = function (e) {
            e = this.toJson(e);
            e = encodeURIComponent(e);
            var m, p = "",
                d, q = 0;
            do {
                var l = (m = e.charCodeAt(q++)) >> 2;
                var t = (3 & m) << 4 | (m = e.charCodeAt(q++)) >> 4;
                var v = (15 & m) << 2 | (d = e.charCodeAt(q++)) >> 6;
                var n = 63 & d;
                isNaN(m) ? v = n = 64 : isNaN(d) && (n = 64);
                p = p + "23IL<N01c7KvwZO56RSTAfghiFyzWJqVabGH4PQdopUrsCuX*xeBjkltDEmn89.-".charAt(l) + "23IL<N01c7KvwZO56RSTAfghiFyzWJqVabGH4PQdopUrsCuX*xeBjkltDEmn89.-".charAt(t) + "23IL<N01c7KvwZO56RSTAfghiFyzWJqVabGH4PQdopUrsCuX*xeBjkltDEmn89.-".charAt(v) + "23IL<N01c7KvwZO56RSTAfghiFyzWJqVabGH4PQdopUrsCuX*xeBjkltDEmn89.-".charAt(n)
            } while (q < e.length);
            return p + "/"
        };
        this.collect = function () {
            var e = new Date;
            try {
                var r = document.createElement("div"),
                    u = {},
                    d = "ActiveBorder ActiveCaption AppWorkspace Background ButtonFace ButtonHighlight ButtonShadow ButtonText CaptionText GrayText Highlight HighlightText InactiveBorder InactiveCaption InactiveCaptionText InfoBackground InfoText Menu MenuText Scrollbar ThreeDDarkShadow ThreeDFace ThreeDHighlight ThreeDLightShadow ThreeDShadow Window WindowFrame WindowText".split(" ");
                if (window.getComputedStyle) for (n = 0; n < d.length; n++) document.body.appendChild(r), r.style.color = d[n], u[d[n]] = window.getComputedStyle(r).getPropertyValue("color"), document.body.removeChild(r)
            } catch (C) { }
            r = {
                ca: {},
                ts: {},
                m: {}
            };
            d = r.ca;
            d.tdHash = _jdfp_canvas_md5;
            d.webglHash = _jdfp_webgl_md5;
            var B = !1;
            if (window.WebGLRenderingContext) {
                for (var l, z = ["webgl", "experimental-webgl", "moz-webgl", "webkit-3d"], y = [], n = 0; n < z.length; n++) try {
                    var w = !1;
                    (w = document.createElement("canvas").getContext(z[n], {
                        stencil: !0
                    })) && w && (l = w, y.push(z[n]))
                } catch (C) { }
                y.length && (B = {
                    name: y,
                    gl: l
                })
            }
            if (B) {
                n = B.gl;
                d.contextName = B.name.join();
                d.webglversion = n.getParameter(n.VERSION);
                d.shadingLV = n.getParameter(n.SHADING_LANGUAGE_VERSION);
                d.vendor = n.getParameter(n.VENDOR);
                d.renderer = n.getParameter(n.RENDERER);
                l = [];
                try {
                    l = n.getSupportedExtensions(), d.extensions = l
                } catch (C) { }
                try {
                    var k = n.getExtension("WEBGL_debug_renderer_info");
                    k && (d.wuv = n.getParameter(k.UNMASKED_VENDOR_WEBGL), d.wur = n.getParameter(k.UNMASKED_RENDERER_WEBGL))
                } catch (C) { }
            }
            r.m.documentMode = document.documentMode;
            r.m.compatMode = document.compatMode;
            k = [];
            d = new m;
            for (n = 0; n < t.length; n++) l = t[n], d.checkSupportFont(l) && k.push(l);
            r.fo = k;
            n = {};
            k = [];
            for (var a in navigator) "object" != typeof navigator[a] && (n[a] = navigator[a]), k.push(a);
            n.enumerationOrder = k;
            n.javaEnabled = navigator.javaEnabled();
            try {
                n.taintEnabled = navigator.taintEnabled()
            } catch (C) { }
            r.n = n;
            var c, b;
            n = navigator.userAgent.toLowerCase();
            (b = n.match(/rv:([\d.]+)\) like gecko/)) && (c = b[1]);
            (b = n.match(/msie ([\d.]+)/)) && (c = b[1]);
            b = [];
            if (c) for (c = "AcroPDF.PDF;Adodb.Stream;AgControl.AgControl;DevalVRXCtrl.DevalVRXCtrl.1;MacromediaFlashPaper.MacromediaFlashPaper;Msxml2.DOMDocument;Msxml2.XMLHTTP;PDF.PdfCtrl;QuickTime.QuickTime;QuickTimeCheckObject.QuickTimeCheck.1;RealPlayer;RealPlayer.RealPlayer(tm) ActiveX Control (32-bit);RealVideo.RealVideo(tm) ActiveX Control (32-bit);rmocx.RealPlayer G2 Control;Scripting.Dictionary;Shell.UIHelper;ShockwaveFlash.ShockwaveFlash;SWCtl.SWCtl;TDCCtl.TDCCtl;WMPlayer.OCX".split(";"), n = 0; n < c.length; n++) {
                var g = c[n];
                try {
                    var f = new ActiveXObject(g);
                    (h = {}).name = g;
                    try {
                        h.version = f.GetVariable("$version")
                    } catch (C) { }
                    try {
                        h.version = f.GetVersions()
                    } catch (C) { }
                    h.version && 0 < h.version.length || (h.version = "");
                    b.push(h)
                } catch (C) { }
            } else {
                c = navigator.plugins;
                var h = {};
                for (n = 0; n < c.length; n++) h[(g = c[n]).name] = 1, b.push(q(g));
                for (n = 0; n < A.length; n++) f = A[n], h[f] || (g = c[f]) && b.push(q(g))
            }
            f = "availHeight availWidth colorDepth bufferDepth deviceXDPI deviceYDPI height width logicalXDPI logicalYDPI pixelDepth updateInterval".split(" ");
            g = {};
            for (n = 0; f.length > n; n++) h = f[n], void 0 !== screen[h] && (g[h] = screen[h]);
            f = ["devicePixelRatio", "screenTop", "screenLeft"];
            c = {};
            for (n = 0; f.length > n; n++) h = f[n], void 0 !== window[h] && (c[h] = window[h]);
            r.p = b;
            r.w = c;
            r.s = g;
            r.sc = u;
            r.tz = e.getTimezoneOffset();
            r.lil = v.sort().join("|");
            r.wil = x;
            e = {};
            try {
                e.cookie = navigator.cookieEnabled, e.localStorage = !!window.localStorage, e.sessionStorage = !!window.sessionStorage, e.globalStorage = !!window.globalStorage, e.indexedDB = !!window.indexedDB
            } catch (C) { }
            return r.ss = e, r.ts.deviceTime = start_time, r.ts.deviceEndTime = (new Date).getTime(), this.tdencrypt(r)
        }
    },
        _JdJrRiskClientCollectData = "",
        _JdJrRiskClientStorage = null,
        _JdJrTdRiskFp = null,
        _JdJrTdRiskFpInfo = "",
        _JdEid = "",
        _eidFlag = !1,
        _JdTdudfp = {};
    !
        function () {
            _jd_load_td_finger_flag && (_JdJrRiskClientStorage = new JDJRTDLOCALSTORAGE, _JdJrTdRiskFp = new JdJrTdRiskFinger, _JdJrRiskClientStorage.get("3AB9D23F7A4B3C9B", function (e) {
                void 0 != e && null != e && 32 <= e.length && (_JdEid = e, _eidFlag = !0)
            }), _JdJrTdRiskFp.get(function (e) {
                _JdJrTdRiskFpInfo = e
            }), td_collect.init(), void 0 !== document.body && document.body ? setTimeout(td_collect_exe, 100) : td_collect_exe())
        }()
};