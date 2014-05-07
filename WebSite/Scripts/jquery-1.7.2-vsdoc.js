/*
* This file has been generated to support Visual Studio IntelliSense.
* You should not use this file at runtime inside the browser--it is only
* intended to be used only for design-time IntelliSense.  Please use the
* standard jQuery library for all production use.
*
* Comment version: 1.7.2
* 中文制作：kkleetom
* 中文来源：http://www.jb51.net/shouce/jQuery-1.6-api/，http://yhz61010.github.com/jquery/
* 制作日期：2012-08-31
*/

/*!
* jQuery JavaScript Library v1.7.2
* http://jquery.com/
*
* Distributed in whole under the terms of the MIT
*
* Copyright 2010, John Resig
*
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the
* "Software"), to deal in the Software without restriction, including
* without limitation the rights to use, copy, modify, merge, publish,
* distribute, sublicense, and/or sell copies of the Software, and to
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:
*
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
* LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
* OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
* WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
* Includes Sizzle.js
* http://sizzlejs.com/
* Copyright 2010, The Dojo Foundation
* Released under the MIT and BSD Licenses.
*/

(function (window, undefined) {
    var jQuery = function (selector, context) {
        /// <summary>
        ///     1: 这个函数接收一个包含 CSS 选择器的字符串，然后用这个字符串去匹配一组元素
        ///     &#10;    1.1 - $(selector, context)
        ///     &#10;    1.2 - $(element)
        ///     &#10;    1.3 - $(object)
        ///     &#10;    1.4 - $(elementArray)
        ///     &#10;    1.5 - $(jQuery object)
        ///     &#10;    1.6 - $()
        ///     &#10;2: 根据提供的原始 HTML 字符串，动态创建 DOM 元素。
        ///     &#10;    2.1 - $(html, ownerDocument)
        ///     &#10;    2.2 - $(html, props)
        ///     &#10;3: 绑定当 DOM 加载完成时执行的函数。
        ///     &#10;    3.1 - $(callback)
        /// </summary>
        /// <param name="selector" type="String">
        ///     用来查找的字符串
        /// </param>
        /// <param name="context" type="jQuery">
        ///     作为待查找的 DOM 元素集、文档或 jQuery 对象。
        /// </param>
        /// <returns type="jQuery" />

        // The jQuery object is actually just the init constructor 'enhanced'
        return new jQuery.fn.init(selector, context, rootjQuery);
    };
    jQuery.Callbacks = function (flags) {
        /// <summary>
        ///     一个多用途的回调列表对象，提供了强大的的方式来管理回调函数列表。
        /// </summary>
        /// <param name="flags" type="String">
        ///     一个用空格标记分隔的标志可选列表,用来改变回调列表中的行为 
        /// </param>


        // Convert flags from String-formatted to Object-formatted
        // (we check in cache first)
        flags = flags ? (flagsCache[flags] || createFlags(flags)) : {};

        var // Actual callback list
		list = [],
		// Stack of fire calls for repeatable lists
		stack = [],
		// Last fire value (for non-forgettable lists)
		memory,
		// Flag to know if list was already fired
		fired,
		// Flag to know if list is currently firing
		firing,
		// First callback to fire (used internally by add and fireWith)
		firingStart,
		// End of the loop when firing
		firingLength,
		// Index of currently firing callback (modified by remove if needed)
		firingIndex,
		// Add one or several callbacks to the list
		add = function (args) {
		    var i,
				length,
				elem,
				type,
				actual;
		    for (i = 0, length = args.length; i < length; i++) {
		        elem = args[i];
		        type = jQuery.type(elem);
		        if (type === "array") {
		            // Inspect recursively
		            add(elem);
		        } else if (type === "function") {
		            // Add if not in unique mode and callback is not in
		            if (!flags.unique || !self.has(elem)) {
		                list.push(elem);
		            }
		        }
		    }
		},
		// Fire callbacks
		fire = function (context, args) {
		    args = args || [];
		    memory = !flags.memory || [context, args];
		    fired = true;
		    firing = true;
		    firingIndex = firingStart || 0;
		    firingStart = 0;
		    firingLength = list.length;
		    for (; list && firingIndex < firingLength; firingIndex++) {
		        if (list[firingIndex].apply(context, args) === false && flags.stopOnFalse) {
		            memory = true; // Mark as halted
		            break;
		        }
		    }
		    firing = false;
		    if (list) {
		        if (!flags.once) {
		            if (stack && stack.length) {
		                memory = stack.shift();
		                self.fireWith(memory[0], memory[1]);
		            }
		        } else if (memory === true) {
		            self.disable();
		        } else {
		            list = [];
		        }
		    }
		},
		// Actual Callbacks object
		self = {
		    // Add a callback or a collection of callbacks to the list
		    add: function () {
		        if (list) {
		            var length = list.length;
		            add(arguments);
		            // Do we need to add the callbacks to the
		            // current firing batch?
		            if (firing) {
		                firingLength = list.length;
		                // With memory, if we're not firing then
		                // we should call right away, unless previous
		                // firing was halted (stopOnFalse)
		            } else if (memory && memory !== true) {
		                firingStart = length;
		                fire(memory[0], memory[1]);
		            }
		        }
		        return this;
		    },
		    // Remove a callback from the list
		    remove: function () {
		        if (list) {
		            var args = arguments,
						argIndex = 0,
						argLength = args.length;
		            for (; argIndex < argLength ; argIndex++) {
		                for (var i = 0; i < list.length; i++) {
		                    if (args[argIndex] === list[i]) {
		                        // Handle firingIndex and firingLength
		                        if (firing) {
		                            if (i <= firingLength) {
		                                firingLength--;
		                                if (i <= firingIndex) {
		                                    firingIndex--;
		                                }
		                            }
		                        }
		                        // Remove the element
		                        list.splice(i--, 1);
		                        // If we have some unicity property then
		                        // we only need to do this once
		                        if (flags.unique) {
		                            break;
		                        }
		                    }
		                }
		            }
		        }
		        return this;
		    },
		    // Control if a given callback is in the list
		    has: function (fn) {
		        if (list) {
		            var i = 0,
						length = list.length;
		            for (; i < length; i++) {
		                if (fn === list[i]) {
		                    return true;
		                }
		            }
		        }
		        return false;
		    },
		    // Remove all callbacks from the list
		    empty: function () {
		        list = [];
		        return this;
		    },
		    // Have the list do nothing anymore
		    disable: function () {
		        list = stack = memory = undefined;
		        return this;
		    },
		    // Is it disabled?
		    disabled: function () {
		        return !list;
		    },
		    // Lock the list in its current state
		    lock: function () {
		        stack = undefined;
		        if (!memory || memory === true) {
		            self.disable();
		        }
		        return this;
		    },
		    // Is it locked?
		    locked: function () {
		        return !stack;
		    },
		    // Call all callbacks with the given context and arguments
		    fireWith: function (context, args) {
		        if (stack) {
		            if (firing) {
		                if (!flags.once) {
		                    stack.push([context, args]);
		                }
		            } else if (!(flags.once && memory)) {
		                fire(context, args);
		            }
		        }
		        return this;
		    },
		    // Call all the callbacks with the given arguments
		    fire: function () {
		        self.fireWith(this, arguments);
		        return this;
		    },
		    // To know if the callbacks have already been called at least once
		    fired: function () {
		        return !!fired;
		    }
		};

        return self;
    };
    jQuery.Deferred = function (func) {

        var doneList = jQuery.Callbacks("once memory"),
			failList = jQuery.Callbacks("once memory"),
			progressList = jQuery.Callbacks("memory"),
			state = "pending",
			lists = {
			    resolve: doneList,
			    reject: failList,
			    notify: progressList
			},
			promise = {
			    done: doneList.add,
			    fail: failList.add,
			    progress: progressList.add,

			    state: function () {
			        return state;
			    },

			    // Deprecated
			    isResolved: doneList.fired,
			    isRejected: failList.fired,

			    then: function (doneCallbacks, failCallbacks, progressCallbacks) {
			        deferred.done(doneCallbacks).fail(failCallbacks).progress(progressCallbacks);
			        return this;
			    },
			    always: function () {
			        deferred.done.apply(deferred, arguments).fail.apply(deferred, arguments);
			        return this;
			    },
			    pipe: function (fnDone, fnFail, fnProgress) {
			        return jQuery.Deferred(function (newDefer) {
			            jQuery.each({
			                done: [fnDone, "resolve"],
			                fail: [fnFail, "reject"],
			                progress: [fnProgress, "notify"]
			            }, function (handler, data) {
			                var fn = data[0],
								action = data[1],
								returned;
			                if (jQuery.isFunction(fn)) {
			                    deferred[handler](function () {
			                        returned = fn.apply(this, arguments);
			                        if (returned && jQuery.isFunction(returned.promise)) {
			                            returned.promise().then(newDefer.resolve, newDefer.reject, newDefer.notify);
			                        } else {
			                            newDefer[action + "With"](this === deferred ? newDefer : this, [returned]);
			                        }
			                    });
			                } else {
			                    deferred[handler](newDefer[action]);
			                }
			            });
			        }).promise();
			    },
			    // Get a promise for this deferred
			    // If obj is provided, the promise aspect is added to the object
			    promise: function (obj) {
			        if (obj == null) {
			            obj = promise;
			        } else {
			            for (var key in promise) {
			                obj[key] = promise[key];
			            }
			        }
			        return obj;
			    }
			},
			deferred = promise.promise({}),
			key;

        for (key in lists) {
            deferred[key] = lists[key].fire;
            deferred[key + "With"] = lists[key].fireWith;
        }

        // Handle state
        deferred.done(function () {
            state = "resolved";
        }, failList.disable, progressList.lock).fail(function () {
            state = "rejected";
        }, doneList.disable, progressList.lock);

        // Call given func if any
        if (func) {
            func.call(deferred, deferred);
        }

        // All done!
        return deferred;
    };
    jQuery.Event = function (src, props) {

        // Allow instantiation without the 'new' keyword
        if (!(this instanceof jQuery.Event)) {
            return new jQuery.Event(src, props);
        }

        // Event object
        if (src && src.type) {
            this.originalEvent = src;
            this.type = src.type;

            // Events bubbling up the document may have been marked as prevented
            // by a handler lower down the tree; reflect the correct value.
            this.isDefaultPrevented = (src.defaultPrevented || src.returnValue === false ||
			src.getPreventDefault && src.getPreventDefault()) ? returnTrue : returnFalse;

            // Event type
        } else {
            this.type = src;
        }

        // Put explicitly provided properties onto the event object
        if (props) {
            jQuery.extend(this, props);
        }

        // Create a timestamp if incoming event doesn't have one
        this.timeStamp = src && src.timeStamp || jQuery.now();

        // Mark it as fixed
        this[jQuery.expando] = true;
    };
    jQuery._data = function (elem, name, data) {

        return jQuery.data(elem, name, data, true);
    };
    jQuery._mark = function (elem, type) {

        if (elem) {
            type = (type || "fx") + "mark";
            jQuery._data(elem, type, (jQuery._data(elem, type) || 0) + 1);
        }
    };
    jQuery._unmark = function (force, elem, type) {

        if (force !== true) {
            type = elem;
            elem = force;
            force = false;
        }
        if (elem) {
            type = type || "fx";
            var key = type + "mark",
				count = force ? 0 : ((jQuery._data(elem, key) || 1) - 1);
            if (count) {
                jQuery._data(elem, key, count);
            } else {
                jQuery.removeData(elem, key, true);
                handleQueueMarkDefer(elem, type, "mark");
            }
        }
    };
    jQuery.acceptData = function (elem) {

        if (elem.nodeName) {
            var match = jQuery.noData[elem.nodeName.toLowerCase()];

            if (match) {
                return !(match === true || elem.getAttribute("classid") !== match);
            }
        }

        return true;
    };
    jQuery.access = function (elems, fn, key, value, chainable, emptyGet, pass) {

        var exec,
			bulk = key == null,
			i = 0,
			length = elems.length;

        // Sets many values
        if (key && typeof key === "object") {
            for (i in key) {
                jQuery.access(elems, fn, i, key[i], 1, emptyGet, value);
            }
            chainable = 1;

            // Sets one value
        } else if (value !== undefined) {
            // Optionally, function values get executed if exec is true
            exec = pass === undefined && jQuery.isFunction(value);

            if (bulk) {
                // Bulk operations only iterate when executing function values
                if (exec) {
                    exec = fn;
                    fn = function (elem, key, value) {
                        return exec.call(jQuery(elem), value);
                    };

                    // Otherwise they run against the entire set
                } else {
                    fn.call(elems, value);
                    fn = null;
                }
            }

            if (fn) {
                for (; i < length; i++) {
                    fn(elems[i], key, exec ? value.call(elems[i], i, fn(elems[i], key)) : value, pass);
                }
            }

            chainable = 1;
        }

        return chainable ?
            elems :

			// Gets
			bulk ?
				fn.call(elems) :
				length ? fn(elems[0], key) : emptyGet;
    };
    jQuery.active = 0;
    jQuery.ajax = function (url, options) {
        /// <summary>
        ///     执行一个异步HTTP(Ajax)请求。
        ///     &#10;1 - jQuery.ajax(url, settings)
        ///     &#10;2 - jQuery.ajax(settings)
        /// </summary>
        /// <param name="url" type="String">
        ///     一个用来包含发送请求的URL字符串。
        /// </param>
        /// <param name="options" type="Object">
        ///     可选参数，一组用于配置 Ajax 请求的键值对。所有的选项都是可选的。任何一个选项的默认值都可以通过 $.ajaxSetup() 来设定。
        /// </param>


        // If url is an object, simulate pre-1.5 signature
        if (typeof url === "object") {
            options = url;
            url = undefined;
        }

        // Force options to be an object
        options = options || {};

        var // Create the final options object
			s = jQuery.ajaxSetup({}, options),
			// Callbacks context
			callbackContext = s.context || s,
			// Context for global events
			// It's the callbackContext if one was provided in the options
			// and if it's a DOM node or a jQuery collection
			globalEventContext = callbackContext !== s &&
				(callbackContext.nodeType || callbackContext instanceof jQuery) ?
						jQuery(callbackContext) : jQuery.event,
			// Deferreds
			deferred = jQuery.Deferred(),
			completeDeferred = jQuery.Callbacks("once memory"),
			// Status-dependent callbacks
			statusCode = s.statusCode || {},
			// ifModified key
			ifModifiedKey,
			// Headers (they are sent all at once)
			requestHeaders = {},
			requestHeadersNames = {},
			// Response headers
			responseHeadersString,
			responseHeaders,
			// transport
			transport,
			// timeout handle
			timeoutTimer,
			// Cross-domain detection vars
			parts,
			// The jqXHR state
			state = 0,
			// To know if global events are to be dispatched
			fireGlobals,
			// Loop variable
			i,
			// Fake xhr
			jqXHR = {

			    readyState: 0,

			    // Caches the header
			    setRequestHeader: function (name, value) {
			        if (!state) {
			            var lname = name.toLowerCase();
			            name = requestHeadersNames[lname] = requestHeadersNames[lname] || name;
			            requestHeaders[name] = value;
			        }
			        return this;
			    },

			    // Raw string
			    getAllResponseHeaders: function () {
			        return state === 2 ? responseHeadersString : null;
			    },

			    // Builds headers hashtable if needed
			    getResponseHeader: function (key) {
			        var match;
			        if (state === 2) {
			            if (!responseHeaders) {
			                responseHeaders = {};
			                while ((match = rheaders.exec(responseHeadersString))) {
			                    responseHeaders[match[1].toLowerCase()] = match[2];
			                }
			            }
			            match = responseHeaders[key.toLowerCase()];
			        }
			        return match === undefined ? null : match;
			    },

			    // Overrides response content-type header
			    overrideMimeType: function (type) {
			        if (!state) {
			            s.mimeType = type;
			        }
			        return this;
			    },

			    // Cancel the request
			    abort: function (statusText) {
			        statusText = statusText || "abort";
			        if (transport) {
			            transport.abort(statusText);
			        }
			        done(0, statusText);
			        return this;
			    }
			};

        // Callback for when everything is done
        // It is defined here because jslint complains if it is declared
        // at the end of the function (which would be more logical and readable)
        function done(status, nativeStatusText, responses, headers) {

            // Called once
            if (state === 2) {
                return;
            }

            // State is "done" now
            state = 2;

            // Clear timeout if it exists
            if (timeoutTimer) {
                clearTimeout(timeoutTimer);
            }

            // Dereference transport for early garbage collection
            // (no matter how long the jqXHR object will be used)
            transport = undefined;

            // Cache response headers
            responseHeadersString = headers || "";

            // Set readyState
            jqXHR.readyState = status > 0 ? 4 : 0;

            var isSuccess,
				success,
				error,
				statusText = nativeStatusText,
				response = responses ? ajaxHandleResponses(s, jqXHR, responses) : undefined,
				lastModified,
				etag;

            // If successful, handle type chaining
            if (status >= 200 && status < 300 || status === 304) {

                // Set the If-Modified-Since and/or If-None-Match header, if in ifModified mode.
                if (s.ifModified) {

                    if ((lastModified = jqXHR.getResponseHeader("Last-Modified"))) {
                        jQuery.lastModified[ifModifiedKey] = lastModified;
                    }
                    if ((etag = jqXHR.getResponseHeader("Etag"))) {
                        jQuery.etag[ifModifiedKey] = etag;
                    }
                }

                // If not modified
                if (status === 304) {

                    statusText = "notmodified";
                    isSuccess = true;

                    // If we have data
                } else {

                    try {
                        success = ajaxConvert(s, response);
                        statusText = "success";
                        isSuccess = true;
                    } catch (e) {
                        // We have a parsererror
                        statusText = "parsererror";
                        error = e;
                    }
                }
            } else {
                // We extract error from statusText
                // then normalize statusText and status for non-aborts
                error = statusText;
                if (!statusText || status) {
                    statusText = "error";
                    if (status < 0) {
                        status = 0;
                    }
                }
            }

            // Set data for the fake xhr object
            jqXHR.status = status;
            jqXHR.statusText = "" + (nativeStatusText || statusText);

            // Success/Error
            if (isSuccess) {
                deferred.resolveWith(callbackContext, [success, statusText, jqXHR]);
            } else {
                deferred.rejectWith(callbackContext, [jqXHR, statusText, error]);
            }

            // Status-dependent callbacks
            jqXHR.statusCode(statusCode);
            statusCode = undefined;

            if (fireGlobals) {
                globalEventContext.trigger("ajax" + (isSuccess ? "Success" : "Error"),
						[jqXHR, s, isSuccess ? success : error]);
            }

            // Complete
            completeDeferred.fireWith(callbackContext, [jqXHR, statusText]);

            if (fireGlobals) {
                globalEventContext.trigger("ajaxComplete", [jqXHR, s]);
                // Handle the global AJAX counter
                if (!(--jQuery.active)) {
                    jQuery.event.trigger("ajaxStop");
                }
            }
        }

        // Attach deferreds
        deferred.promise(jqXHR);
        jqXHR.success = jqXHR.done;
        jqXHR.error = jqXHR.fail;
        jqXHR.complete = completeDeferred.add;

        // Status-dependent callbacks
        jqXHR.statusCode = function (map) {
            if (map) {
                var tmp;
                if (state < 2) {
                    for (tmp in map) {
                        statusCode[tmp] = [statusCode[tmp], map[tmp]];
                    }
                } else {
                    tmp = map[jqXHR.status];
                    jqXHR.then(tmp, tmp);
                }
            }
            return this;
        };

        // Remove hash character (#7531: and string promotion)
        // Add protocol if not provided (#5866: IE7 issue with protocol-less urls)
        // We also use the url parameter if available
        s.url = ((url || s.url) + "").replace(rhash, "").replace(rprotocol, ajaxLocParts[1] + "//");

        // Extract dataTypes list
        s.dataTypes = jQuery.trim(s.dataType || "*").toLowerCase().split(rspacesAjax);

        // Determine if a cross-domain request is in order
        if (s.crossDomain == null) {
            parts = rurl.exec(s.url.toLowerCase());
            s.crossDomain = !!(parts &&
				(parts[1] != ajaxLocParts[1] || parts[2] != ajaxLocParts[2] ||
					(parts[3] || (parts[1] === "http:" ? 80 : 443)) !=
						(ajaxLocParts[3] || (ajaxLocParts[1] === "http:" ? 80 : 443)))
			);
        }

        // Convert data if not already a string
        if (s.data && s.processData && typeof s.data !== "string") {
            s.data = jQuery.param(s.data, s.traditional);
        }

        // Apply prefilters
        inspectPrefiltersOrTransports(prefilters, s, options, jqXHR);

        // If request was aborted inside a prefilter, stop there
        if (state === 2) {
            return false;
        }

        // We can fire global events as of now if asked to
        fireGlobals = s.global;

        // Uppercase the type
        s.type = s.type.toUpperCase();

        // Determine if request has content
        s.hasContent = !rnoContent.test(s.type);

        // Watch for a new set of requests
        if (fireGlobals && jQuery.active++ === 0) {
            jQuery.event.trigger("ajaxStart");
        }

        // More options handling for requests with no content
        if (!s.hasContent) {

            // If data is available, append data to url
            if (s.data) {
                s.url += (rquery.test(s.url) ? "&" : "?") + s.data;
                // #9682: remove data so that it's not used in an eventual retry
                delete s.data;
            }

            // Get ifModifiedKey before adding the anti-cache parameter
            ifModifiedKey = s.url;

            // Add anti-cache in url if needed
            if (s.cache === false) {

                var ts = jQuery.now(),
					// try replacing _= if it is there
					ret = s.url.replace(rts, "$1_=" + ts);

                // if nothing was replaced, add timestamp to the end
                s.url = ret + ((ret === s.url) ? (rquery.test(s.url) ? "&" : "?") + "_=" + ts : "");
            }
        }

        // Set the correct header, if data is being sent
        if (s.data && s.hasContent && s.contentType !== false || options.contentType) {
            jqXHR.setRequestHeader("Content-Type", s.contentType);
        }

        // Set the If-Modified-Since and/or If-None-Match header, if in ifModified mode.
        if (s.ifModified) {
            ifModifiedKey = ifModifiedKey || s.url;
            if (jQuery.lastModified[ifModifiedKey]) {
                jqXHR.setRequestHeader("If-Modified-Since", jQuery.lastModified[ifModifiedKey]);
            }
            if (jQuery.etag[ifModifiedKey]) {
                jqXHR.setRequestHeader("If-None-Match", jQuery.etag[ifModifiedKey]);
            }
        }

        // Set the Accepts header for the server, depending on the dataType
        jqXHR.setRequestHeader(
			"Accept",
			s.dataTypes[0] && s.accepts[s.dataTypes[0]] ?
				s.accepts[s.dataTypes[0]] + (s.dataTypes[0] !== "*" ? ", " + allTypes + "; q=0.01" : "") :
				s.accepts["*"]
		);

        // Check for headers option
        for (i in s.headers) {
            jqXHR.setRequestHeader(i, s.headers[i]);
        }

        // Allow custom headers/mimetypes and early abort
        if (s.beforeSend && (s.beforeSend.call(callbackContext, jqXHR, s) === false || state === 2)) {
            // Abort if not done already
            jqXHR.abort();
            return false;

        }

        // Install callbacks on deferreds
        for (i in { success: 1, error: 1, complete: 1 }) {
            jqXHR[i](s[i]);
        }

        // Get transport
        transport = inspectPrefiltersOrTransports(transports, s, options, jqXHR);

        // If no transport, we auto-abort
        if (!transport) {
            done(-1, "No Transport");
        } else {
            jqXHR.readyState = 1;
            // Send global event
            if (fireGlobals) {
                globalEventContext.trigger("ajaxSend", [jqXHR, s]);
            }
            // Timeout
            if (s.async && s.timeout > 0) {
                timeoutTimer = setTimeout(function () {
                    jqXHR.abort("timeout");
                }, s.timeout);
            }

            try {
                state = 1;
                transport.send(requestHeaders, done);
            } catch (e) {
                // Propagate exception as error if not done
                if (state < 2) {
                    done(-1, e);
                    // Simply rethrow otherwise
                } else {
                    throw e;
                }
            }
        }

        return jqXHR;
    };
    jQuery.ajaxPrefilter = function (dataTypeExpression, func) {
        /// <summary>
        ///     预前过滤器，用于在每个请求发送之前，并且在 $.ajax() 处理之前，设置自定义 Ajax 选项或者修改已经存在的选项。
        /// </summary>
        /// <param name="dataTypeExpression" type="String">
        ///     一个可选的字符串，包含一个或多个用空格分隔的数据类型（dataTypes）。
        /// </param>
        /// <param name="func" type="Function">
        ///     用于设置今后 Ajax 请求用的默认值
        /// </param>
        /// <returns type="undefined" />


        if (typeof dataTypeExpression !== "string") {
            func = dataTypeExpression;
            dataTypeExpression = "*";
        }

        if (jQuery.isFunction(func)) {
            var dataTypes = dataTypeExpression.toLowerCase().split(rspacesAjax),
				i = 0,
				length = dataTypes.length,
				dataType,
				list,
				placeBefore;

            // For each dataType in the dataTypeExpression
            for (; i < length; i++) {
                dataType = dataTypes[i];
                // We control if we're asked to add before
                // any existing element
                placeBefore = /^\+/.test(dataType);
                if (placeBefore) {
                    dataType = dataType.substr(1) || "*";
                }
                list = structure[dataType] = structure[dataType] || [];
                // then we add to the structure accordingly
                list[placeBefore ? "unshift" : "push"](func);
            }
        }
    };
    jQuery.ajaxSettings = {
        "url": 'http://localhost:25812/',
        "isLocal": false,
        "global": true,
        "type": 'GET',
        "contentType": 'application/x-www-form-urlencoded; charset=UTF-8',
        "processData": true,
        "async": true,
        "accepts": {},
        "contents": {},
        "responseFields": {},
        "converters": {},
        "flatOptions": {},
        "jsonp": 'callback'
    };
    jQuery.ajaxSetup = function (target, settings) {
        /// <summary>
        ///     给未来的 Ajax 请求设置默认值。
        /// </summary>
        /// <param name="target" type="Object">
        ///      一组用于配置 Ajax 请求的键值对。所有的选项都是可选的。
        /// </param>

        if (settings) {
            // Building a settings object
            ajaxExtend(target, jQuery.ajaxSettings);
        } else {
            // Extending ajaxSettings
            settings = target;
            target = jQuery.ajaxSettings;
        }
        ajaxExtend(target, settings);
        return target;
    };
    jQuery.ajaxTransport = function (dataTypeExpression, func) {


        if (typeof dataTypeExpression !== "string") {
            func = dataTypeExpression;
            dataTypeExpression = "*";
        }

        if (jQuery.isFunction(func)) {
            var dataTypes = dataTypeExpression.toLowerCase().split(rspacesAjax),
				i = 0,
				length = dataTypes.length,
				dataType,
				list,
				placeBefore;

            // For each dataType in the dataTypeExpression
            for (; i < length; i++) {
                dataType = dataTypes[i];
                // We control if we're asked to add before
                // any existing element
                placeBefore = /^\+/.test(dataType);
                if (placeBefore) {
                    dataType = dataType.substr(1) || "*";
                }
                list = structure[dataType] = structure[dataType] || [];
                // then we add to the structure accordingly
                list[placeBefore ? "unshift" : "push"](func);
            }
        }
    };
    jQuery.attr = function (elem, name, value, pass) {

        var ret, hooks, notxml,
			nType = elem.nodeType;

        // don't get/set attributes on text, comment and attribute nodes
        if (!elem || nType === 3 || nType === 8 || nType === 2) {
            return;
        }

        if (pass && name in jQuery.attrFn) {
            return jQuery(elem)[name](value);
        }

        // Fallback to prop when attributes are not supported
        if (typeof elem.getAttribute === "undefined") {
            return jQuery.prop(elem, name, value);
        }

        notxml = nType !== 1 || !jQuery.isXMLDoc(elem);

        // All attributes are lowercase
        // Grab necessary hook if one is defined
        if (notxml) {
            name = name.toLowerCase();
            hooks = jQuery.attrHooks[name] || (rboolean.test(name) ? boolHook : nodeHook);
        }

        if (value !== undefined) {

            if (value === null) {
                jQuery.removeAttr(elem, name);
                return;

            } else if (hooks && "set" in hooks && notxml && (ret = hooks.set(elem, value, name)) !== undefined) {
                return ret;

            } else {
                elem.setAttribute(name, "" + value);
                return value;
            }

        } else if (hooks && "get" in hooks && notxml && (ret = hooks.get(elem, name)) !== null) {
            return ret;

        } else {

            ret = elem.getAttribute(name);

            // Non-existent attributes return null, we normalize to undefined
            return ret === null ?
                undefined :
				ret;
        }
    };
    jQuery.attrFn = {
        "val": true,
        "css": true,
        "html": true,
        "text": true,
        "data": true,
        "width": true,
        "height": true,
        "offset": true,
        "blur": true,
        "focus": true,
        "focusin": true,
        "focusout": true,
        "load": true,
        "resize": true,
        "scroll": true,
        "unload": true,
        "click": true,
        "dblclick": true,
        "mousedown": true,
        "mouseup": true,
        "mousemove": true,
        "mouseover": true,
        "mouseout": true,
        "mouseenter": true,
        "mouseleave": true,
        "change": true,
        "select": true,
        "submit": true,
        "keydown": true,
        "keypress": true,
        "keyup": true,
        "error": true,
        "contextmenu": true
    };
    jQuery.attrHooks = {
        "type": {},
        "value": {},
        "tabindex": {}
    };
    jQuery.bindReady = function () {

        if (readyList) {
            return;
        }

        readyList = jQuery.Callbacks("once memory");

        // Catch cases where $(document).ready() is called after the
        // browser event has already occurred.
        if (document.readyState === "complete") {
            // Handle it asynchronously to allow scripts the opportunity to delay ready
            return setTimeout(jQuery.ready, 1);
        }

        // Mozilla, Opera and webkit nightlies currently support this event
        if (document.addEventListener) {
            // Use the handy event callback
            document.addEventListener("DOMContentLoaded", DOMContentLoaded, false);

            // A fallback to window.onload, that will always work
            window.addEventListener("load", jQuery.ready, false);

            // If IE event model is used
        } else if (document.attachEvent) {
            // ensure firing before onload,
            // maybe late but safe also for iframes
            document.attachEvent("onreadystatechange", DOMContentLoaded);

            // A fallback to window.onload, that will always work
            window.attachEvent("onload", jQuery.ready);

            // If IE and not a frame
            // continually check to see if the document is ready
            var toplevel = false;

            try {
                toplevel = window.frameElement == null;
            } catch (e) { }

            if (document.documentElement.doScroll && toplevel) {
                doScrollCheck();
            }
        }
    };
    jQuery.boxModel = true;
    jQuery.browser = {
        "msie": true,
        "version": '10.0'
    };
    jQuery.buildFragment = function (args, nodes, scripts) {

        var fragment, cacheable, cacheresults, doc,
	first = args[0];

        // nodes may contain either an explicit document object,
        // a jQuery collection or context object.
        // If nodes[0] contains a valid object to assign to doc
        if (nodes && nodes[0]) {
            doc = nodes[0].ownerDocument || nodes[0];
        }

        // Ensure that an attr object doesn't incorrectly stand in as a document object
        // Chrome and Firefox seem to allow this to occur and will throw exception
        // Fixes #8950
        if (!doc.createDocumentFragment) {
            doc = document;
        }

        // Only cache "small" (1/2 KB) HTML strings that are associated with the main document
        // Cloning options loses the selected state, so don't cache them
        // IE 6 doesn't like it when you put <object> or <embed> elements in a fragment
        // Also, WebKit does not clone 'checked' attributes on cloneNode, so don't cache
        // Lastly, IE6,7,8 will not correctly reuse cached fragments that were created from unknown elems #10501
        if (args.length === 1 && typeof first === "string" && first.length < 512 && doc === document &&
		first.charAt(0) === "<" && !rnocache.test(first) &&
		(jQuery.support.checkClone || !rchecked.test(first)) &&
		(jQuery.support.html5Clone || !rnoshimcache.test(first))) {

		    cacheable = true;

		    cacheresults = jQuery.fragments[first];
		    if (cacheresults && cacheresults !== 1) {
		        fragment = cacheresults;
		    }
		}

        if (!fragment) {
            fragment = doc.createDocumentFragment();
            jQuery.clean(args, doc, fragment, scripts);
        }

        if (cacheable) {
            jQuery.fragments[first] = cacheresults ? fragment : 1;
        }

        return { fragment: fragment, cacheable: cacheable };
    };
    jQuery.cache = {};
    jQuery.camelCase = function (string) {

        return string.replace(rmsPrefix, "ms-").replace(rdashAlpha, fcamelCase);
    };
    jQuery.clean = function (elems, context, fragment, scripts) {

        var checkScriptType, script, j,
				ret = [];

        context = context || document;

        // !context.createElement fails in IE with an error but returns typeof 'object'
        if (typeof context.createElement === "undefined") {
            context = context.ownerDocument || context[0] && context[0].ownerDocument || document;
        }

        for (var i = 0, elem; (elem = elems[i]) != null; i++) {
            if (typeof elem === "number") {
                elem += "";
            }

            if (!elem) {
                continue;
            }

            // Convert html string into DOM nodes
            if (typeof elem === "string") {
                if (!rhtml.test(elem)) {
                    elem = context.createTextNode(elem);
                } else {
                    // Fix "XHTML"-style tags in all browsers
                    elem = elem.replace(rxhtmlTag, "<$1></$2>");

                    // Trim whitespace, otherwise indexOf won't work as expected
                    var tag = (rtagName.exec(elem) || ["", ""])[1].toLowerCase(),
						wrap = wrapMap[tag] || wrapMap._default,
						depth = wrap[0],
						div = context.createElement("div"),
						safeChildNodes = safeFragment.childNodes,
						remove;

                    // Append wrapper element to unknown element safe doc fragment
                    if (context === document) {
                        // Use the fragment we've already created for this document
                        safeFragment.appendChild(div);
                    } else {
                        // Use a fragment created with the owner document
                        createSafeFragment(context).appendChild(div);
                    }

                    // Go to html and back, then peel off extra wrappers
                    div.innerHTML = wrap[1] + elem + wrap[2];

                    // Move to the right depth
                    while (depth--) {
                        div = div.lastChild;
                    }

                    // Remove IE's autoinserted <tbody> from table fragments
                    if (!jQuery.support.tbody) {

                        // String was a <table>, *may* have spurious <tbody>
                        var hasBody = rtbody.test(elem),
							tbody = tag === "table" && !hasBody ?
								div.firstChild && div.firstChild.childNodes :

								// String was a bare <thead> or <tfoot>
								wrap[1] === "<table>" && !hasBody ?
									div.childNodes :
									[];

                        for (j = tbody.length - 1; j >= 0 ; --j) {
                            if (jQuery.nodeName(tbody[j], "tbody") && !tbody[j].childNodes.length) {
                                tbody[j].parentNode.removeChild(tbody[j]);
                            }
                        }
                    }

                    // IE completely kills leading whitespace when innerHTML is used
                    if (!jQuery.support.leadingWhitespace && rleadingWhitespace.test(elem)) {
                        div.insertBefore(context.createTextNode(rleadingWhitespace.exec(elem)[0]), div.firstChild);
                    }

                    elem = div.childNodes;

                    // Clear elements from DocumentFragment (safeFragment or otherwise)
                    // to avoid hoarding elements. Fixes #11356
                    if (div) {
                        div.parentNode.removeChild(div);

                        // Guard against -1 index exceptions in FF3.6
                        if (safeChildNodes.length > 0) {
                            remove = safeChildNodes[safeChildNodes.length - 1];

                            if (remove && remove.parentNode) {
                                remove.parentNode.removeChild(remove);
                            }
                        }
                    }
                }
            }

            // Resets defaultChecked for any radios and checkboxes
            // about to be appended to the DOM in IE 6/7 (#8060)
            var len;
            if (!jQuery.support.appendChecked) {
                if (elem[0] && typeof (len = elem.length) === "number") {
                    for (j = 0; j < len; j++) {
                        findInputs(elem[j]);
                    }
                } else {
                    findInputs(elem);
                }
            }

            if (elem.nodeType) {
                ret.push(elem);
            } else {
                ret = jQuery.merge(ret, elem);
            }
        }

        if (fragment) {
            checkScriptType = function (elem) {
                return !elem.type || rscriptType.test(elem.type);
            };
            for (i = 0; ret[i]; i++) {
                script = ret[i];
                if (scripts && jQuery.nodeName(script, "script") && (!script.type || rscriptType.test(script.type))) {
                    scripts.push(script.parentNode ? script.parentNode.removeChild(script) : script);

                } else {
                    if (script.nodeType === 1) {
                        var jsTags = jQuery.grep(script.getElementsByTagName("script"), checkScriptType);

                        ret.splice.apply(ret, [i + 1, 0].concat(jsTags));
                    }
                    fragment.appendChild(script);
                }
            }
        }

        return ret;
    };
    jQuery.cleanData = function (elems) {

        var data, id,
			cache = jQuery.cache,
			special = jQuery.event.special,
			deleteExpando = jQuery.support.deleteExpando;

        for (var i = 0, elem; (elem = elems[i]) != null; i++) {
            if (elem.nodeName && jQuery.noData[elem.nodeName.toLowerCase()]) {
                continue;
            }

            id = elem[jQuery.expando];

            if (id) {
                data = cache[id];

                if (data && data.events) {
                    for (var type in data.events) {
                        if (special[type]) {
                            jQuery.event.remove(elem, type);

                            // This is a shortcut to avoid jQuery.event.remove's overhead
                        } else {
                            jQuery.removeEvent(elem, type, data.handle);
                        }
                    }

                    // Null the DOM reference to avoid IE6/7/8 leak (#7054)
                    if (data.handle) {
                        data.handle.elem = null;
                    }
                }

                if (deleteExpando) {
                    delete elem[jQuery.expando];

                } else if (elem.removeAttribute) {
                    elem.removeAttribute(jQuery.expando);
                }

                delete cache[id];
            }
        }
    };
    jQuery.clone = function (elem, dataAndEvents, deepDataAndEvents) {

        var srcElements,
			destElements,
			i,
			// IE<=8 does not properly clone detached, unknown element nodes
			clone = jQuery.support.html5Clone || jQuery.isXMLDoc(elem) || !rnoshimcache.test("<" + elem.nodeName + ">") ?
				elem.cloneNode(true) :
				shimCloneNode(elem);

        if ((!jQuery.support.noCloneEvent || !jQuery.support.noCloneChecked) &&
				(elem.nodeType === 1 || elem.nodeType === 11) && !jQuery.isXMLDoc(elem)) {
            // IE copies events bound via attachEvent when using cloneNode.
            // Calling detachEvent on the clone will also remove the events
            // from the original. In order to get around this, we use some
            // proprietary methods to clear the events. Thanks to MooTools
            // guys for this hotness.

				    cloneFixAttributes(elem, clone);

				    // Using Sizzle here is crazy slow, so we use getElementsByTagName instead
				    srcElements = getAll(elem);
				    destElements = getAll(clone);

				    // Weird iteration because IE will replace the length property
				    // with an element if you are cloning the body and one of the
				    // elements on the page has a name or id of "length"
				    for (i = 0; srcElements[i]; ++i) {
				        // Ensure that the destination node is not null; Fixes #9587
				        if (destElements[i]) {
				            cloneFixAttributes(srcElements[i], destElements[i]);
				        }
				    }
				}

        // Copy the events from the original to the clone
        if (dataAndEvents) {
            cloneCopyEvent(elem, clone);

            if (deepDataAndEvents) {
                srcElements = getAll(elem);
                destElements = getAll(clone);

                for (i = 0; srcElements[i]; ++i) {
                    cloneCopyEvent(srcElements[i], destElements[i]);
                }
            }
        }

        srcElements = destElements = null;

        // Return the cloned set
        return clone;
    };
    jQuery.contains = function (a, b) {
        /// <summary>
        ///     检测一个DOM节点是否包含另一个DOM节点
        /// </summary>
        /// <param name="a" domElement="true">
        ///     可能包含其它元素的DOM元素。
        /// </param>
        /// <param name="b" domElement="true">
        ///     可能被其它元素包含的DOM节点。 
        /// </param>
        /// <returns type="Boolean" />

        return a !== b && (a.contains ? a.contains(b) : true);
    };
    jQuery.css = function (elem, name, extra) {

        var ret, hooks;

        // Make sure that we're working with the right name
        name = jQuery.camelCase(name);
        hooks = jQuery.cssHooks[name];
        name = jQuery.cssProps[name] || name;

        // cssFloat needs a special treatment
        if (name === "cssFloat") {
            name = "float";
        }

        // If a hook was provided get the computed value from there
        if (hooks && "get" in hooks && (ret = hooks.get(elem, true, extra)) !== undefined) {
            return ret;

            // Otherwise, if a way to get the computed value exists, use that
        } else if (curCSS) {
            return curCSS(elem, name);
        }
    };
    jQuery.cssHooks = {
        "opacity": {},
        "height": {},
        "width": {},
        "margin": {},
        "padding": {},
        "borderWidth": {}
    };
    jQuery.cssNumber = {
        "fillOpacity": true,
        "fontWeight": true,
        "lineHeight": true,
        "opacity": true,
        "orphans": true,
        "widows": true,
        "zIndex": true,
        "zoom": true
    };
    jQuery.cssProps = { "float": 'cssFloat' };
    jQuery.curCSS = function (elem, name, extra) {

        var ret, hooks;

        // Make sure that we're working with the right name
        name = jQuery.camelCase(name);
        hooks = jQuery.cssHooks[name];
        name = jQuery.cssProps[name] || name;

        // cssFloat needs a special treatment
        if (name === "cssFloat") {
            name = "float";
        }

        // If a hook was provided get the computed value from there
        if (hooks && "get" in hooks && (ret = hooks.get(elem, true, extra)) !== undefined) {
            return ret;

            // Otherwise, if a way to get the computed value exists, use that
        } else if (curCSS) {
            return curCSS(elem, name);
        }
    };
    jQuery.data = function (elem, name, data, pvt /* Internal Use Only */) {
        /// <summary>
        ///     1: 在匹配的元素上随心所欲的存放数据。
        ///     &#10;    1.1 - jQuery.data(element, key, value)
        ///     &#10;2: 返回 jQuery 对象集合中第一个元素上储存的数据，这个数据是先前用data(name, value)设定的。
        ///     &#10;    2.1 - jQuery.data(element, key)
        ///     &#10;    2.2 - jQuery.data(element)
        /// </summary>
        /// <param name="elem" domElement="true">
        ///     用于存放数据用的 DOM 元素。
        /// </param>
        /// <param name="name" type="String">
        ///      一个字符串键，代表将要被存储的数据。 
        /// </param>
        /// <param name="data" type="Object">
        ///     新的数据值。 
        /// </param>
        /// <returns type="Object" />

        if (!jQuery.acceptData(elem)) {
            return;
        }

        var privateCache, thisCache, ret,
			internalKey = jQuery.expando,
			getByName = typeof name === "string",

			// We have to handle DOM nodes and JS objects differently because IE6-7
			// can't GC object references properly across the DOM-JS boundary
			isNode = elem.nodeType,

			// Only DOM nodes need the global jQuery cache; JS object data is
			// attached directly to the object so GC can occur automatically
			cache = isNode ? jQuery.cache : elem,

			// Only defining an ID for JS objects if its cache already exists allows
			// the code to shortcut on the same path as a DOM node with no cache
			id = isNode ? elem[internalKey] : elem[internalKey] && internalKey,
			isEvents = name === "events";

        // Avoid doing any more work than we need to when trying to get data on an
        // object that has no data at all
        if ((!id || !cache[id] || (!isEvents && !pvt && !cache[id].data)) && getByName && data === undefined) {
            return;
        }

        if (!id) {
            // Only DOM nodes need a new unique ID for each element since their data
            // ends up in the global cache
            if (isNode) {
                elem[internalKey] = id = ++jQuery.uuid;
            } else {
                id = internalKey;
            }
        }

        if (!cache[id]) {
            cache[id] = {};

            // Avoids exposing jQuery metadata on plain JS objects when the object
            // is serialized using JSON.stringify
            if (!isNode) {
                cache[id].toJSON = jQuery.noop;
            }
        }

        // An object can be passed to jQuery.data instead of a key/value pair; this gets
        // shallow copied over onto the existing cache
        if (typeof name === "object" || typeof name === "function") {
            if (pvt) {
                cache[id] = jQuery.extend(cache[id], name);
            } else {
                cache[id].data = jQuery.extend(cache[id].data, name);
            }
        }

        privateCache = thisCache = cache[id];

        // jQuery data() is stored in a separate object inside the object's internal data
        // cache in order to avoid key collisions between internal data and user-defined
        // data.
        if (!pvt) {
            if (!thisCache.data) {
                thisCache.data = {};
            }

            thisCache = thisCache.data;
        }

        if (data !== undefined) {
            thisCache[jQuery.camelCase(name)] = data;
        }

        // Users should not attempt to inspect the internal events object using jQuery.data,
        // it is undocumented and subject to change. But does anyone listen? No.
        if (isEvents && !thisCache[name]) {
            return privateCache.events;
        }

        // Check for both converted-to-camel and non-converted data property names
        // If a data property was specified
        if (getByName) {

            // First Try to find as-is property data
            ret = thisCache[name];

            // Test for null|undefined property data
            if (ret == null) {

                // Try to find the camelCased property
                ret = thisCache[jQuery.camelCase(name)];
            }
        } else {
            ret = thisCache;
        }

        return ret;
    };
    jQuery.dequeue = function (elem, type) {
        /// <summary>
        ///     执行匹配元素上函数队列中的下一个函数。
        /// </summary>
        /// <param name="elem" domElement="true">
        ///     一个用于移除和执行列队的DOM元素
        /// </param>
        /// <param name="type" type="String">
        ///     一个含有队列名的字符串。默认是"fx"，标准的动画队列
        /// </param>
        /// <returns type="undefined" />

        type = type || "fx";

        var queue = jQuery.queue(elem, type),
			fn = queue.shift(),
			hooks = {};

        // If the fx queue is dequeued, always remove the progress sentinel
        if (fn === "inprogress") {
            fn = queue.shift();
        }

        if (fn) {
            // Add a progress sentinel to prevent the fx queue from being
            // automatically dequeued
            if (type === "fx") {
                queue.unshift("inprogress");
            }

            jQuery._data(elem, type + ".run", hooks);
            fn.call(elem, function () {
                jQuery.dequeue(elem, type);
            }, hooks);
        }

        if (!queue.length) {
            jQuery.removeData(elem, type + "queue " + type + ".run", true);
            handleQueueMarkDefer(elem, type, "queue");
        }
    };
    jQuery.dir = function (elem, dir, until) {

        var matched = [],
			cur = elem[dir];

        while (cur && cur.nodeType !== 9 && (until === undefined || cur.nodeType !== 1 || !jQuery(cur).is(until))) {
            if (cur.nodeType === 1) {
                matched.push(cur);
            }
            cur = cur[dir];
        }
        return matched;
    };
    jQuery.each = function (object, callback, args) {
        /// <summary>
        ///     通用的迭代函数，用于无缝的迭代对象及数组。含有 length 属性的数组和类数组（array-like）对象(例如，函数的 arguments 对象)会按索引值进行迭代，迭代的索引值从 0 开始，到 length-1 结束。其它的对象会按照它们的属性名进行迭代。
        /// </summary>
        /// <param name="object" type="Object">
        ///      将要用于迭代的对象或数组。 
        /// </param>
        /// <param name="callback" type="Function">
        ///      该函数会在每次迭代时被调用。
        /// </param>
        /// <returns type="Object" />

        var name, i = 0,
			length = object.length,
			isObj = length === undefined || jQuery.isFunction(object);

        if (args) {
            if (isObj) {
                for (name in object) {
                    if (callback.apply(object[name], args) === false) {
                        break;
                    }
                }
            } else {
                for (; i < length;) {
                    if (callback.apply(object[i++], args) === false) {
                        break;
                    }
                }
            }

            // A special, fast, case for the most common use of each
        } else {
            if (isObj) {
                for (name in object) {
                    if (callback.call(object[name], name, object[name]) === false) {
                        break;
                    }
                }
            } else {
                for (; i < length;) {
                    if (callback.call(object[i], i, object[i++]) === false) {
                        break;
                    }
                }
            }
        }

        return object;
    };
    jQuery.easing = {};
    jQuery.error = function (msg) {
        /// <summary>
        ///     接受一个字符串，并抛出包含这个字符串的异常。
        /// </summary>
        /// <param name="msg" type="String">
        ///     将要被发送的消息。
        /// </param>

        throw new Error(msg);
    };
    jQuery.etag = {};
    jQuery.event = {
        "global": {},
        "customEvent": {},
        "props": ['attrChange', 'attrName', 'relatedNode', 'srcElement', 'altKey', 'bubbles', 'cancelable', 'ctrlKey', 'currentTarget', 'eventPhase', 'metaKey', 'relatedTarget', 'shiftKey', 'target', 'timeStamp', 'view', 'which'],
        "fixHooks": {},
        "keyHooks": {},
        "mouseHooks": {},
        "special": {},
        "triggered": {}
    };
    jQuery.expr = {
        "order": ['ID', 'CLASS', 'NAME', 'TAG'],
        "match": {},
        "leftMatch": {},
        "attrMap": {},
        "attrHandle": {},
        "relative": {},
        "find": {},
        "preFilter": {},
        "filters": {},
        "setFilters": {},
        "filter": {},
        ":": {}
    };
    jQuery.extend = function () {
        /// <summary>
        ///     将两个或多个对象的内容合并到第一个对象中。
        ///     &#10;1 - jQuery.extend(target, object1, objectN)
        ///     &#10;2 - jQuery.extend(deep, target, object1, objectN)
        /// </summary>
        /// <param name="" type="Boolean">
        ///     如果该参数为 true，那么将进行递归合并(也就是深拷贝)。
        /// </param>
        /// <param name="" type="Object">
        ///     用于扩展的对象。用于接收新的属性。
        /// </param>
        /// <param name="" type="Object">
        ///     将要被合并的包含额外属性的对象。
        /// </param>
        /// <param name="" type="Object">
        ///     可选的对象，包含将要被合并的属性。 
        /// </param>
        /// <returns type="Object" />

        var options, name, src, copy, copyIsArray, clone,
		target = arguments[0] || {},
		i = 1,
		length = arguments.length,
		deep = false;

        // Handle a deep copy situation
        if (typeof target === "boolean") {
            deep = target;
            target = arguments[1] || {};
            // skip the boolean and the target
            i = 2;
        }

        // Handle case when target is a string or something (possible in deep copy)
        if (typeof target !== "object" && !jQuery.isFunction(target)) {
            target = {};
        }

        // extend jQuery itself if only one argument is passed
        if (length === i) {
            target = this;
            --i;
        }

        for (; i < length; i++) {
            // Only deal with non-null/undefined values
            if ((options = arguments[i]) != null) {
                // Extend the base object
                for (name in options) {
                    src = target[name];
                    copy = options[name];

                    // Prevent never-ending loop
                    if (target === copy) {
                        continue;
                    }

                    // Recurse if we're merging plain objects or arrays
                    if (deep && copy && (jQuery.isPlainObject(copy) || (copyIsArray = jQuery.isArray(copy)))) {
                        if (copyIsArray) {
                            copyIsArray = false;
                            clone = src && jQuery.isArray(src) ? src : [];

                        } else {
                            clone = src && jQuery.isPlainObject(src) ? src : {};
                        }

                        // Never move original objects, clone them
                        target[name] = jQuery.extend(deep, clone, copy);

                        // Don't bring in undefined values
                    } else if (copy !== undefined) {
                        target[name] = copy;
                    }
                }
            }
        }

        // Return the modified object
        return target;
    };
    jQuery.filter = function (expr, elems, not) {

        if (not) {
            expr = ":not(" + expr + ")";
        }

        return elems.length === 1 ?
			jQuery.find.matchesSelector(elems[0], expr) ? [elems[0]] : [] :
			jQuery.find.matches(expr, elems);
    };
    jQuery.find = function (query, context, extra, seed) {

        context = context || document;

        // Only use querySelectorAll on non-XML documents
        // (ID selectors don't work in non-HTML documents)
        if (!seed && !Sizzle.isXML(context)) {
            // See if we find a selector to speed up
            var match = /^(\w+$)|^\.([\w\-]+$)|^#([\w\-]+$)/.exec(query);

            if (match && (context.nodeType === 1 || context.nodeType === 9)) {
                // Speed-up: Sizzle("TAG")
                if (match[1]) {
                    return makeArray(context.getElementsByTagName(query), extra);

                    // Speed-up: Sizzle(".CLASS")
                } else if (match[2] && Expr.find.CLASS && context.getElementsByClassName) {
                    return makeArray(context.getElementsByClassName(match[2]), extra);
                }
            }

            if (context.nodeType === 9) {
                // Speed-up: Sizzle("body")
                // The body element only exists once, optimize finding it
                if (query === "body" && context.body) {
                    return makeArray([context.body], extra);

                    // Speed-up: Sizzle("#ID")
                } else if (match && match[3]) {
                    var elem = context.getElementById(match[3]);

                    // Check parentNode to catch when Blackberry 4.6 returns
                    // nodes that are no longer in the document #6963
                    if (elem && elem.parentNode) {
                        // Handle the case where IE and Opera return items
                        // by name instead of ID
                        if (elem.id === match[3]) {
                            return makeArray([elem], extra);
                        }

                    } else {
                        return makeArray([], extra);
                    }
                }

                try {
                    return makeArray(context.querySelectorAll(query), extra);
                } catch (qsaError) { }

                // qSA works strangely on Element-rooted queries
                // We can work around this by specifying an extra ID on the root
                // and working up from there (Thanks to Andrew Dupont for the technique)
                // IE 8 doesn't work on object elements
            } else if (context.nodeType === 1 && context.nodeName.toLowerCase() !== "object") {
                var oldContext = context,
						old = context.getAttribute("id"),
						nid = old || id,
						hasParent = context.parentNode,
						relativeHierarchySelector = /^\s*[+~]/.test(query);

                if (!old) {
                    context.setAttribute("id", nid);
                } else {
                    nid = nid.replace(/'/g, "\\$&");
                }
                if (relativeHierarchySelector && hasParent) {
                    context = context.parentNode;
                }

                try {
                    if (!relativeHierarchySelector || hasParent) {
                        return makeArray(context.querySelectorAll("[id='" + nid + "'] " + query), extra);
                    }

                } catch (pseudoError) {
                } finally {
                    if (!old) {
                        oldContext.removeAttribute("id");
                    }
                }
            }
        }

        return oldSizzle(query, context, extra, seed);
    };
    jQuery.fn = {
        "selector": '',
        "jquery": '1.7.2',
        "length": 0
    };
    jQuery.fragments = {};
    jQuery.fx = function (elem, options, prop) {

        this.options = options;
        this.elem = elem;
        this.prop = prop;

        options.orig = options.orig || {};
    };
    jQuery.get = function (url, data, callback, type) {
        /// <summary>
        ///     通过 HTTP GET 方式从服务器载入数据。
        /// </summary>
        /// <param name="url" type="String">
        ///    将要被请求的 URL 字符串。
        /// </param>
        /// <param name="data" type="String">
        ///     发送给服务器的字符串或者映射。
        /// </param>
        /// <param name="callback" type="Function">
        ///     当请求成功后执行的回调函数。
        /// </param>
        /// <param name="type" type="String">
        ///     预计从服务器返回的数据类型。默认值：智能匹配 (xml, json, script, 或 html)。
        /// </param>

        // shift arguments if data argument was omitted
        if (jQuery.isFunction(data)) {
            type = type || callback;
            callback = data;
            data = undefined;
        }

        return jQuery.ajax({
            type: method,
            url: url,
            data: data,
            success: callback,
            dataType: type
        });
    };
    jQuery.getJSON = function (url, data, callback) {
        /// <summary>
        ///     通过 HTTP GET 方式从服务器载入 JSON 编码的数据。
        /// </summary>
        /// <param name="url" type="String">
        ///      将要被请求的 URL 字符串。
        /// </param>
        /// <param name="data" type="Object">
        ///     可选参数，发送给服务器的字符串或者映射。
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，当请求成功后执行的回调函数。
        /// </param>

        return jQuery.get(url, data, callback, "json");
    };
    jQuery.getScript = function (url, callback) {
        /// <summary>
        ///     通过 HTTP GET 方式从服务器请求一个 JavaScript 文件，并执行它。
        /// </summary>
        /// <param name="url" type="String">
        ///      将要被请求的 URL 字符串。
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，当请求成功后执行的回调函数。
        /// </param>

        return jQuery.get(url, undefined, callback, "script");
    };
    jQuery.globalEval = function (data) {
        /// <summary>
        ///     在全局范围下执行一些JavaScript代码
        /// </summary>
        /// <param name="data" type="String">
        ///     用来执行的JavaScript代码
        /// </param>

        if (data && rnotwhite.test(data)) {
            // We use execScript on Internet Explorer
            // We use an anonymous function so that context is window
            // rather than jQuery in Firefox
            (window.execScript || function (data) {
                window["eval"].call(window, data);
            })(data);
        }
    };
    jQuery.grep = function (elems, callback, inv) {
        /// <summary>
        ///     在数组中查找满足过滤器函数的元素。本方法不会影响原数组
        /// </summary>
        /// <param name="elems" type="Array">
        ///     用于查找元素的数组
        /// </param>
        /// <param name="callback" type="Function">
        ///      过滤元素用的函数。第一个参数是正在被检查的数组的元素，第二个参数是该元素的索引值。该函数返回一个布尔值。函数中的 this 代表了全局的 window 对象
        /// </param>
        /// <param name="inv" type="Boolean">
        ///      可选参数，如果 "invert" 为 false，或者不提供该参数，那么该方法返回的数组中的元素是那些在过滤方法中返回 true 的元素。如果将 "invert" 设置成 true，那么该方法返回的数组中的元素是那些在过滤方法中返回 false 的元素。
        /// </param>
        /// <returns type="Array" />

        var ret = [], retVal;
        inv = !!inv;

        // Go through the array, only saving the items
        // that pass the validator function
        for (var i = 0, length = elems.length; i < length; i++) {
            retVal = !!callback(elems[i], i);
            if (inv !== retVal) {
                ret.push(elems[i]);
            }
        }

        return ret;
    };
    jQuery.guid = 1;
    jQuery.hasData = function (elem) {
        /// <summary>
        ///     判断一个元素是否含有 jQuery data.
        /// </summary>
        /// <param name="elem" domElement="true">
        ///     用于检查是否含有 jQuery data 的元素。
        /// </param>
        /// <returns type="Boolean" />

        elem = elem.nodeType ? jQuery.cache[elem[jQuery.expando]] : elem[jQuery.expando];
        return !!elem && !isEmptyDataObject(elem);
    };
    jQuery.holdReady = function (hold) {
        /// <summary>
        ///     持有或释放 jQuery 的 ready 事件的执行。
        /// </summary>
        /// <param name="hold" type="Boolean">
        ///      表示是否正在请求持有或释放 ready 事件。
        /// </param>
        /// <returns type="undefined" />

        if (hold) {
            jQuery.readyWait++;
        } else {
            jQuery.ready(true);
        }
    };
    jQuery.inArray = function (elem, array, i) {
        /// <summary>
        ///     在数组中查找指定的值，返回该值的索引值(若没有找到该值，则返回 -1)
        /// </summary>
        /// <param name="elem" type="Object">
        ///     将要查找的值.
        /// </param>
        /// <param name="array" type="Array">
        ///     将会在该数组中进行值查找.
        /// </param>
        /// <param name="i" type="Number">
        ///      可选参数，将要查找的起始索引值。默认值是 0，代表在整个数组中进行查找
        /// </param>
        /// <returns type="Number" />

        var len;

        if (array) {
            if (indexOf) {
                return indexOf.call(array, elem, i);
            }

            len = array.length;
            i = i ? i < 0 ? Math.max(0, len + i) : i : 0;

            for (; i < len; i++) {
                // Skip accessing in sparse arrays
                if (i in array && array[i] === elem) {
                    return i;
                }
            }
        }

        return -1;
    };
    jQuery.isArray = Array.isArray || function (obj) {
        /// <summary>
        ///     判断传入的参数是否为数组。
        /// </summary>
        /// <returns type="Boolean" />
        return jQuery.type(obj) === "array";
    };
    jQuery.isEmptyObject = function (obj) {
        /// <summary>
        ///     测试一个对象是否为空对象（不包含任何属性）。
        /// </summary>
        /// <param name="obj" type="Object">
        ///      用于检测是否为空的对象。
        /// </param>
        /// <returns type="Boolean" />

        for (var name in obj) {
            return false;
        }
        return true;
    };
    jQuery.isFunction = function (obj) {
        /// <summary>
        ///     判断传入的参数是否为 Javascript 函数对象
        /// </summary>
        /// <param name="obj" type="Object">
        ///     将要被检查的对象。用于判断该对象是否为函数
        /// </param>
        /// <returns type="Boolean" />

        return jQuery.type(obj) === "function";
    };
    jQuery.isNumeric = function (obj) {
        /// <summary>
        ///     判断传入的参数是否为数字。
        /// </summary>
        /// <param name="obj" type="Object">
        ///     将要被检查的值
        /// </param>
        /// <returns type="Boolean" />

        return !isNaN(parseFloat(obj)) && isFinite(obj);
    };
    jQuery.isPlainObject = function (obj) {
        /// <summary>
        ///     测试一个对象是否是纯粹的对象（通过 "{}" 或者 "new Object" 创建的）.
        /// </summary>
        /// <param name="obj" type="Object">
        ///     用于被检测的对象
        /// </param>
        /// <returns type="Boolean" />

        // Must be an Object.
        // Because of IE, we also have to check the presence of the constructor property.
        // Make sure that DOM nodes and window objects don't pass through, as well
        if (!obj || jQuery.type(obj) !== "object" || obj.nodeType || jQuery.isWindow(obj)) {
            return false;
        }

        try {
            // Not own constructor property must be Object
            if (obj.constructor &&
				!hasOwn.call(obj, "constructor") &&
				!hasOwn.call(obj.constructor.prototype, "isPrototypeOf")) {
				    return false;
				}
        } catch (e) {
            // IE8,9 Will throw exceptions on certain host objects #9897
            return false;
        }

        // Own properties are enumerated firstly, so to speed up,
        // if last one is own, then all properties are own.

        var key;
        for (key in obj) { }

        return key === undefined || hasOwn.call(obj, key);
    };
    jQuery.isReady = true;
    jQuery.isWindow = function (obj) {
        /// <summary>
        ///     判断传入的参数是否为 window 对象.
        /// </summary>
        /// <param name="obj" type="Object">
        ///     将要被检查的对象。用于判断该对象是否为 window.
        /// </param>
        /// <returns type="Boolean" />

        return obj != null && obj == obj.window;
    };
    jQuery.isXMLDoc = function (elem) {
        /// <summary>
        ///     检查一个DOM节点是否在XML文档中（或者是一个XML文档）
        /// </summary>
        /// <param name="elem" domElement="true">
        ///     用来检查是否在一个XML文档中的DOM节点
        /// </param>
        /// <returns type="Boolean" />

        // documentElement is verified for cases where it doesn't yet exist
        // (such as loading iframes in IE - #4833)
        var documentElement = (elem ? elem.ownerDocument || elem : 0).documentElement;

        return documentElement ? documentElement.nodeName !== "HTML" : false;
    };
    jQuery.lastModified = {};
    jQuery.makeArray = function (array, results) {
        /// <summary>
        ///     将一个类数组（array-like）的对象，转换成一个真正的 JavaScript 数组
        /// </summary>
        /// <param name="array" type="Object">
        ///     任何将要被转换成原生数组的对象.
        /// </param>
        /// <returns type="Array" />

        var ret = results || [];

        if (array != null) {
            // The window, strings (and functions) also have 'length'
            // Tweaked logic slightly to handle Blackberry 4.7 RegExp issues #6930
            var type = jQuery.type(array);

            if (array.length == null || type === "string" || type === "function" || type === "regexp" || jQuery.isWindow(array)) {
                push.call(ret, array);
            } else {
                jQuery.merge(ret, array);
            }
        }

        return ret;
    };
    jQuery.map = function (elems, callback, arg) {
        /// <summary>
        ///     为数组或对象中的每一个元素应用一个转换函数，并将转换后的结果添加到新生成的数组中
        ///     &#10;1 - jQuery.map(array, callback(elementOfArray, indexInArray))
        ///     &#10;2 - jQuery.map(arrayOrObject, callback( value, indexOrKey ))
        /// </summary>
        /// <param name="elems" type="Array">
        ///      用于应用转换的数组
        /// </param>
        /// <param name="callback" type="Function">
        ///     处理每一个元素的函数。第一个参数是数组中元素或对象的值，第二个参数是该元素在数组中的索引值或该对象的键。该函数可以返回任何值，该返回值会被添加到数组中。若返回是数组，则会将该数组中的元素添加到最终的结果数组中。在函数内部，this 是指向全局(window)对象的
        /// </param>
        /// <returns type="Array" />

        var value, key, ret = [],
			i = 0,
			length = elems.length,
			// jquery objects are treated as arrays
			isArray = elems instanceof jQuery || length !== undefined && typeof length === "number" && ((length > 0 && elems[0] && elems[length - 1]) || length === 0 || jQuery.isArray(elems));

        // Go through the array, translating each of the items to their
        if (isArray) {
            for (; i < length; i++) {
                value = callback(elems[i], i, arg);

                if (value != null) {
                    ret[ret.length] = value;
                }
            }

            // Go through every key on the object,
        } else {
            for (key in elems) {
                value = callback(elems[key], key, arg);

                if (value != null) {
                    ret[ret.length] = value;
                }
            }
        }

        // Flatten any nested arrays
        return ret.concat.apply([], ret);
    };
    jQuery.merge = function (first, second) {
        /// <summary>
        ///     将两个数组的内容合并到第一个数组中.
        /// </summary>
        /// <param name="first" type="Array">
        ///      第一个用于合并的数组，其中将会包含合并后的第二个数组的内容.
        /// </param>
        /// <param name="second" type="Array">
        ///     第二个用于合并的数组，该数组不会被修改，其中的内容将会被合并到第一个数组中
        /// </param>
        /// <returns type="Array" />

        var i = first.length,
			j = 0;

        if (typeof second.length === "number") {
            for (var l = second.length; j < l; j++) {
                first[i++] = second[j];
            }

        } else {
            while (second[j] !== undefined) {
                first[i++] = second[j++];
            }
        }

        first.length = i;

        return first;
    };
    jQuery.noConflict = function (deep) {
        /// <summary>
        ///     让 jQuery 放弃对 $ 变量的控制权.
        /// </summary>
        /// <param name="deep" type="Boolean">
        ///     可选参数，布尔值，用于确定是否在全局作用域中移除所有 jQuery 变量（包括 jQuery 本身）
        /// </param>
        /// <returns type="Object" />

        if (window.$ === jQuery) {
            window.$ = _$;
        }

        if (deep && window.jQuery === jQuery) {
            window.jQuery = _jQuery;
        }

        return jQuery;
    };
    jQuery.noData = {
        "embed": true,
        "object": 'clsid:D27CDB6E-AE6D-11cf-96B8-444553540000',
        "applet": true
    };
    jQuery.nodeName = function (elem, name) {

        return elem.nodeName && elem.nodeName.toUpperCase() === name.toUpperCase();
    };
    jQuery.noop = function () {
        /// <summary>
        ///     一个空函数。
        /// </summary>
        /// <returns type="Function" />
    };
    jQuery.now = function () {
        /// <summary>
        ///     返回一个数字,表示当前时间。
        /// </summary>
        /// <returns type="Number" />

        return (new Date()).getTime();
    };
    jQuery.nth = function (cur, result, dir, elem) {

        result = result || 1;
        var num = 0;

        for (; cur; cur = cur[dir]) {
            if (cur.nodeType === 1 && ++num === result) {
                break;
            }
        }

        return cur;
    };
    jQuery.offset = {};
    jQuery.param = function (a, traditional) {
        /// <summary>
        ///     创建一个数组或者对象的序列化字符串。适用于 URL 查询字符串或者 Ajax 请求
        ///     &#10;1 - jQuery.param(obj)
        ///     &#10;2 - jQuery.param(obj, traditional)
        /// </summary>
        /// <param name="a" type="Object">
        ///      用于序列化的数组或对象。
        /// </param>
        /// <param name="traditional" type="Boolean">
        ///     一个布尔值，用于确定是否使用传统的“浅层”("shallow")序列化。
        /// </param>
        /// <returns type="String" />

        var s = [],
			add = function (key, value) {
			    // If value is a function, invoke it and return its value
			    value = jQuery.isFunction(value) ? value() : value;
			    s[s.length] = encodeURIComponent(key) + "=" + encodeURIComponent(value);
			};

        // Set traditional to true for jQuery <= 1.3.2 behavior.
        if (traditional === undefined) {
            traditional = jQuery.ajaxSettings.traditional;
        }

        // If an array was passed in, assume that it is an array of form elements.
        if (jQuery.isArray(a) || (a.jquery && !jQuery.isPlainObject(a))) {
            // Serialize the form elements
            jQuery.each(a, function () {
                add(this.name, this.value);
            });

        } else {
            // If traditional, encode the "old" way (the way 1.3.2 or older
            // did it), otherwise encode params recursively.
            for (var prefix in a) {
                buildParams(prefix, a[prefix], traditional, add);
            }
        }

        // Return the resulting serialization
        return s.join("&").replace(r20, "+");
    };
    jQuery.parseJSON = function (data) {
        /// <summary>
        ///     接受一个标准格式的 JSON 字符串，并返回解析后的 JavaScript 对象。
        /// </summary>
        /// <param name="data" type="String">
        ///     将要解析的 JSON 字符串
        /// </param>
        /// <returns type="Object" />

        if (typeof data !== "string" || !data) {
            return null;
        }

        // Make sure leading/trailing whitespace is removed (IE can't handle it)
        data = jQuery.trim(data);

        // Attempt to parse using the native JSON parser first
        if (window.JSON && window.JSON.parse) {
            return window.JSON.parse(data);
        }

        // Make sure the incoming data is actual JSON
        // Logic borrowed from http://json.org/json2.js
        if (rvalidchars.test(data.replace(rvalidescape, "@")
			.replace(rvalidtokens, "]")
			.replace(rvalidbraces, ""))) {

			    return (new Function("return " + data))();

			}
        jQuery.error("Invalid JSON: " + data);
    };
    jQuery.parseXML = function (data) {
        /// <summary>
        ///     解析一个字符串到一个XML文件.
        /// </summary>
        /// <param name="data" type="String">
        ///     用来解析的格式良好的XML字符串
        /// </param>
        /// <returns type="XMLDocument" />

        if (typeof data !== "string" || !data) {
            return null;
        }
        var xml, tmp;
        try {
            if (window.DOMParser) { // Standard
                tmp = new DOMParser();
                xml = tmp.parseFromString(data, "text/xml");
            } else { // IE
                xml = new ActiveXObject("Microsoft.XMLDOM");
                xml.async = "false";
                xml.loadXML(data);
            }
        } catch (e) {
            xml = undefined;
        }
        if (!xml || !xml.documentElement || xml.getElementsByTagName("parsererror").length) {
            jQuery.error("Invalid XML: " + data);
        }
        return xml;
    };
    jQuery.post = function (url, data, callback, type) {
        /// <summary>
        ///     通过 HTTP POST 方式从服务器载入数据.
        /// </summary>
        /// <param name="url" type="String">
        ///     将要被请求的 URL 字符串.
        /// </param>
        /// <param name="data" type="String">
        ///     可选参数，发送给服务器的字符串或者映射.
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，当请求成功后执行的回调函数
        /// </param>
        /// <param name="type" type="String">
        ///      可选参数，预计从服务器返回的数据类型。默认值：智能匹配 (xml, json, script, text 或 html)
        /// </param>

        // shift arguments if data argument was omitted
        if (jQuery.isFunction(data)) {
            type = type || callback;
            callback = data;
            data = undefined;
        }

        return jQuery.ajax({
            type: method,
            url: url,
            data: data,
            success: callback,
            dataType: type
        });
    };
    jQuery.prop = function (elem, name, value) {

        var ret, hooks, notxml,
			nType = elem.nodeType;

        // don't get/set properties on text, comment and attribute nodes
        if (!elem || nType === 3 || nType === 8 || nType === 2) {
            return;
        }

        notxml = nType !== 1 || !jQuery.isXMLDoc(elem);

        if (notxml) {
            // Fix name and attach hooks
            name = jQuery.propFix[name] || name;
            hooks = jQuery.propHooks[name];
        }

        if (value !== undefined) {
            if (hooks && "set" in hooks && (ret = hooks.set(elem, value, name)) !== undefined) {
                return ret;

            } else {
                return (elem[name] = value);
            }

        } else {
            if (hooks && "get" in hooks && (ret = hooks.get(elem, name)) !== null) {
                return ret;

            } else {
                return elem[name];
            }
        }
    };
    jQuery.propFix = {
        "tabindex": 'tabIndex',
        "readonly": 'readOnly',
        "for": 'htmlFor',
        "class": 'className',
        "maxlength": 'maxLength',
        "cellspacing": 'cellSpacing',
        "cellpadding": 'cellPadding',
        "rowspan": 'rowSpan',
        "colspan": 'colSpan',
        "usemap": 'useMap',
        "frameborder": 'frameBorder',
        "contenteditable": 'contentEditable'
    };
    jQuery.propHooks = {
        "tabIndex": {},
        "selected": {}
    };
    jQuery.proxy = function (fn, context) {
        /// <summary>
        ///     接受一个函数，然后返回一个新函数，并且这个新函数始终保持了特定的上下文语境
        ///     &#10;1 - jQuery.proxy(function, context)
        ///     &#10;2 - jQuery.proxy(context, name)
        /// </summary>
        /// <param name="fn" type="Function">
        ///      将要改变上下文语境的函数.
        /// </param>
        /// <param name="context" type="Object">
        ///      函数的上下文语境(this)会被设置成这个 object 对象.
        /// </param>
        /// <returns type="Function" />

        if (typeof context === "string") {
            var tmp = fn[context];
            context = fn;
            fn = tmp;
        }

        // Quick check to determine if target is callable, in the spec
        // this throws a TypeError, but we will just return undefined.
        if (!jQuery.isFunction(fn)) {
            return undefined;
        }

        // Simulated bind
        var args = slice.call(arguments, 2),
			proxy = function () {
			    return fn.apply(context, args.concat(slice.call(arguments)));
			};

        // Set the guid of unique handler to the same of original handler, so it can be removed
        proxy.guid = fn.guid = fn.guid || proxy.guid || jQuery.guid++;

        return proxy;
    };
    jQuery.queue = function (elem, type, data) {
        /// <summary>
        ///     1: 显示在匹配的元素上的已经执行的函数列队.
        ///     &#10;    1.1 - jQuery.queue(element, queueName)
        ///     &#10;2: 在匹配元素上操作已经附加函数的列表
        ///     &#10;    2.1 - jQuery.queue(element, queueName, newQueue)
        ///     &#10;    2.2 - jQuery.queue(element, queueName, callback())
        /// </summary>
        /// <param name="elem" domElement="true">
        ///     一个用于检查附加列队的DOM元素。
        /// </param>
        /// <param name="type" type="String">
        ///     一个含有队列名的字符串。默认是"Fx"，标准的动画队列.
        /// </param>
        /// <param name="data" type="Array">
        ///     一个函数数组替换当前队列的内容。
        /// </param>
        /// <returns type="jQuery" />

        var q;
        if (elem) {
            type = (type || "fx") + "queue";
            q = jQuery._data(elem, type);

            // Speed up dequeue by getting out quickly if this is just a lookup
            if (data) {
                if (!q || jQuery.isArray(data)) {
                    q = jQuery._data(elem, type, jQuery.makeArray(data));
                } else {
                    q.push(data);
                }
            }
            return q || [];
        }
    };
    jQuery.ready = function (wait) {

        // Either a released hold or an DOMready/load event and not yet ready
        if ((wait === true && !--jQuery.readyWait) || (wait !== true && !jQuery.isReady)) {
            // Make sure body exists, at least, in case IE gets a little overzealous (ticket #5443).
            if (!document.body) {
                return setTimeout(jQuery.ready, 1);
            }

            // Remember that the DOM is ready
            jQuery.isReady = true;

            // If a normal DOM Ready event fired, decrement, and wait if need be
            if (wait !== true && --jQuery.readyWait > 0) {
                return;
            }

            // If there are functions bound, to execute
            readyList.fireWith(document, [jQuery]);

            // Trigger any bound ready events
            if (jQuery.fn.trigger) {
                jQuery(document).trigger("ready").off("ready");
            }
        }
    };
    jQuery.readyWait = 0;
    jQuery.removeAttr = function (elem, value) {

        var propName, attrNames, name, l, isBool,
			i = 0;

        if (value && elem.nodeType === 1) {
            attrNames = value.toLowerCase().split(rspace);
            l = attrNames.length;

            for (; i < l; i++) {
                name = attrNames[i];

                if (name) {
                    propName = jQuery.propFix[name] || name;
                    isBool = rboolean.test(name);

                    // See #9699 for explanation of this approach (setting first, then removal)
                    // Do not do this for boolean attributes (see #10870)
                    if (!isBool) {
                        jQuery.attr(elem, name, "");
                    }
                    elem.removeAttribute(getSetAttribute ? name : propName);

                    // Set corresponding property to false for boolean attributes
                    if (isBool && propName in elem) {
                        elem[propName] = false;
                    }
                }
            }
        }
    };
    jQuery.removeData = function (elem, name, pvt /* Internal Use Only */) {
        /// <summary>
        ///     移除先前在元素上存放的数据.
        /// </summary>
        /// <param name="elem" domElement="true">
        ///     要被移除数据的DOM元素
        /// </param>
        /// <param name="name" type="String">
        ///     可选参数，一个字符串键，代表将要被移除的数据
        /// </param>
        /// <returns type="jQuery" />

        if (!jQuery.acceptData(elem)) {
            return;
        }

        var thisCache, i, l,

			// Reference to internal data cache key
			internalKey = jQuery.expando,

			isNode = elem.nodeType,

			// See jQuery.data for more information
			cache = isNode ? jQuery.cache : elem,

			// See jQuery.data for more information
			id = isNode ? elem[internalKey] : internalKey;

        // If there is already no cache entry for this object, there is no
        // purpose in continuing
        if (!cache[id]) {
            return;
        }

        if (name) {

            thisCache = pvt ? cache[id] : cache[id].data;

            if (thisCache) {

                // Support array or space separated string names for data keys
                if (!jQuery.isArray(name)) {

                    // try the string as a key before any manipulation
                    if (name in thisCache) {
                        name = [name];
                    } else {

                        // split the camel cased version by spaces unless a key with the spaces exists
                        name = jQuery.camelCase(name);
                        if (name in thisCache) {
                            name = [name];
                        } else {
                            name = name.split(" ");
                        }
                    }
                }

                for (i = 0, l = name.length; i < l; i++) {
                    delete thisCache[name[i]];
                }

                // If there is no data left in the cache, we want to continue
                // and let the cache object itself get destroyed
                if (!(pvt ? isEmptyDataObject : jQuery.isEmptyObject)(thisCache)) {
                    return;
                }
            }
        }

        // See jQuery.data for more information
        if (!pvt) {
            delete cache[id].data;

            // Don't destroy the parent cache unless the internal data object
            // had been the only thing left in it
            if (!isEmptyDataObject(cache[id])) {
                return;
            }
        }

        // Browsers that fail expando deletion also refuse to delete expandos on
        // the window, but it will allow it on all other JS objects; other browsers
        // don't care
        // Ensure that `cache` is not a window object #10080
        if (jQuery.support.deleteExpando || !cache.setInterval) {
            delete cache[id];
        } else {
            cache[id] = null;
        }

        // We destroyed the cache and need to eliminate the expando on the node to avoid
        // false lookups in the cache for entries that no longer exist
        if (isNode) {
            // IE does not allow us to delete expando properties from nodes,
            // nor does it have a removeAttribute function on Document nodes;
            // we must handle all of these cases
            if (jQuery.support.deleteExpando) {
                delete elem[internalKey];
            } else if (elem.removeAttribute) {
                elem.removeAttribute(internalKey);
            } else {
                elem[internalKey] = null;
            }
        }
    };
    jQuery.removeEvent = function (elem, type, handle) {

        if (elem.removeEventListener) {
            elem.removeEventListener(type, handle, false);
        }
    };
    jQuery.sibling = function (n, elem) {

        var r = [];

        for (; n; n = n.nextSibling) {
            if (n.nodeType === 1 && n !== elem) {
                r.push(n);
            }
        }

        return r;
    };
    jQuery.speed = function (speed, easing, fn) {

        var opt = speed && typeof speed === "object" ? jQuery.extend({}, speed) : {
            complete: fn || !fn && easing ||
				jQuery.isFunction(speed) && speed,
            duration: speed,
            easing: fn && easing || easing && !jQuery.isFunction(easing) && easing
        };

        opt.duration = jQuery.fx.off ? 0 : typeof opt.duration === "number" ? opt.duration :
			opt.duration in jQuery.fx.speeds ? jQuery.fx.speeds[opt.duration] : jQuery.fx.speeds._default;

        // normalize opt.queue - true/undefined/null -> "fx"
        if (opt.queue == null || opt.queue === true) {
            opt.queue = "fx";
        }

        // Queueing
        opt.old = opt.complete;

        opt.complete = function (noUnmark) {
            if (jQuery.isFunction(opt.old)) {
                opt.old.call(this);
            }

            if (opt.queue) {
                jQuery.dequeue(this, opt.queue);
            } else if (noUnmark !== false) {
                jQuery._unmark(this);
            }
        };

        return opt;
    };
    jQuery.style = function (elem, name, value, extra) {

        // Don't set styles on text and comment nodes
        if (!elem || elem.nodeType === 3 || elem.nodeType === 8 || !elem.style) {
            return;
        }

        // Make sure that we're working with the right name
        var ret, type, origName = jQuery.camelCase(name),
			style = elem.style, hooks = jQuery.cssHooks[origName];

        name = jQuery.cssProps[origName] || origName;

        // Check if we're setting a value
        if (value !== undefined) {
            type = typeof value;

            // convert relative number strings (+= or -=) to relative numbers. #7345
            if (type === "string" && (ret = rrelNum.exec(value))) {
                value = (+(ret[1] + 1) * +ret[2]) + parseFloat(jQuery.css(elem, name));
                // Fixes bug #9237
                type = "number";
            }

            // Make sure that NaN and null values aren't set. See: #7116
            if (value == null || type === "number" && isNaN(value)) {
                return;
            }

            // If a number was passed in, add 'px' to the (except for certain CSS properties)
            if (type === "number" && !jQuery.cssNumber[origName]) {
                value += "px";
            }

            // If a hook was provided, use that value, otherwise just set the specified value
            if (!hooks || !("set" in hooks) || (value = hooks.set(elem, value)) !== undefined) {
                // Wrapped to prevent IE from throwing errors when 'invalid' values are provided
                // Fixes bug #5509
                try {
                    style[name] = value;
                } catch (e) { }
            }

        } else {
            // If a hook was provided get the non-computed value from there
            if (hooks && "get" in hooks && (ret = hooks.get(elem, false, extra)) !== undefined) {
                return ret;
            }

            // Otherwise just get the value from the style object
            return style[name];
        }
    };
    jQuery.sub = function () {
        /// <summary>
        ///     创建一个 jQuery 的副本，可以修改这个 jQuery 副本的属性和方法而不影响原始的 jQuery 对象
        /// </summary>
        /// <returns type="jQuery" />

        function jQuerySub(selector, context) {
            return new jQuerySub.fn.init(selector, context);
        }
        jQuery.extend(true, jQuerySub, this);
        jQuerySub.superclass = this;
        jQuerySub.fn = jQuerySub.prototype = this();
        jQuerySub.fn.constructor = jQuerySub;
        jQuerySub.sub = this.sub;
        jQuerySub.fn.init = function init(selector, context) {
            if (context && context instanceof jQuery && !(context instanceof jQuerySub)) {
                context = jQuerySub(context);
            }

            return jQuery.fn.init.call(this, selector, context, rootjQuerySub);
        };
        jQuerySub.fn.init.prototype = jQuerySub.fn;
        var rootjQuerySub = jQuerySub(document);
        return jQuerySub;
    };
    jQuery.support = {
        "leadingWhitespace": true,
        "tbody": true,
        "htmlSerialize": true,
        "style": true,
        "hrefNormalized": true,
        "opacity": true,
        "cssFloat": true,
        "checkOn": true,
        "optSelected": false,
        "getSetAttribute": true,
        "enctype": true,
        "html5Clone": true,
        "submitBubbles": true,
        "changeBubbles": true,
        "focusinBubbles": true,
        "deleteExpando": true,
        "noCloneEvent": true,
        "inlineBlockNeedsLayout": false,
        "shrinkWrapBlocks": false,
        "reliableMarginRight": true,
        "pixelMargin": true,
        "boxModel": true,
        "noCloneChecked": false,
        "optDisabled": true,
        "radioValue": false,
        "checkClone": true,
        "appendChecked": true,
        "ajax": true,
        "cors": true,
        "reliableHiddenOffsets": true,
        "doesNotAddBorder": true,
        "doesAddBorderForTableAndCells": true,
        "fixedPosition": true,
        "subtractsBorderForOverflowNotVisible": false,
        "doesNotIncludeMarginInBodyOffset": true
    };
    jQuery.swap = function (elem, options, callback) {

        var old = {},
			ret, name;

        // Remember the old values, and insert the new ones
        for (name in options) {
            old[name] = elem.style[name];
            elem.style[name] = options[name];
        }

        ret = callback.call(elem);

        // Revert the old values
        for (name in options) {
            elem.style[name] = old[name];
        }

        return ret;
    };
    jQuery.text = function (elem) {

        var i, node,
		nodeType = elem.nodeType,
		ret = "";

        if (nodeType) {
            if (nodeType === 1 || nodeType === 9 || nodeType === 11) {
                // Use textContent || innerText for elements
                if (typeof elem.textContent === 'string') {
                    return elem.textContent;
                } else if (typeof elem.innerText === 'string') {
                    // Replace IE's carriage returns
                    return elem.innerText.replace(rReturn, '');
                } else {
                    // Traverse it's children
                    for (elem = elem.firstChild; elem; elem = elem.nextSibling) {
                        ret += getText(elem);
                    }
                }
            } else if (nodeType === 3 || nodeType === 4) {
                return elem.nodeValue;
            }
        } else {

            // If no nodeType, this is expected to be an array
            for (i = 0; (node = elem[i]) ; i++) {
                // Do not traverse comment nodes
                if (node.nodeType !== 8) {
                    ret += getText(node);
                }
            }
        }
        return ret;
    };
    jQuery.trim = function (text) {
        /// <summary>
        ///     移除字符串中开始和结束处的空格.
        /// </summary>
        /// <param name="text" type="String">
        ///     将要被移除空格的字符串.
        /// </param>
        /// <returns type="String" />

        return text == null ?
				"" :
				trim.call(text);
    };
    jQuery.type = function (obj) {
        /// <summary>
        ///     判断内部 JavaScript 对象的 [[Class]]。
        /// </summary>
        /// <param name="obj" type="Object">
        ///     需要取得内部 JavaScript [[Class]] 的对象。
        /// </param>
        /// <returns type="String" />

        return obj == null ?
			String(obj) :
			class2type[toString.call(obj)] || "object";
    };
    jQuery.uaMatch = function (ua) {

        ua = ua.toLowerCase();

        var match = rwebkit.exec(ua) ||
			ropera.exec(ua) ||
			rmsie.exec(ua) ||
			ua.indexOf("compatible") < 0 && rmozilla.exec(ua) ||
			[];

        return { browser: match[1] || "", version: match[2] || "0" };
    };
    jQuery.unique = function (results) {
        /// <summary>
        ///     对 DOM 元素数组进行排序，并删除重复的元素。注意，该方法只能应用于 DOM 元素数组，无法在字符串数组或数字数组上使用。
        /// </summary>
        /// <param name="results" type="Array">
        ///     DOM 元素数组
        /// </param>
        /// <returns type="Array" />

        if (sortOrder) {
            hasDuplicate = baseHasDuplicate;
            results.sort(sortOrder);

            if (hasDuplicate) {
                for (var i = 1; i < results.length; i++) {
                    if (results[i] === results[i - 1]) {
                        results.splice(i--, 1);
                    }
                }
            }
        }

        return results;
    };
    jQuery.uuid = 0;
    jQuery.valHooks = {
        "option": {},
        "select": {},
        "radio": {},
        "checkbox": {}
    };
    jQuery.when = function (firstParam) {
        /// <summary>
        ///     提供了一种在一个或多个对象上执行回调函数的方法。通常，延迟对象代表异步事件。
        /// </summary>
        /// <param name="firstParam" type="Deferred">
        ///      一个或多个延迟对象，或是纯 JavaScript 对象
        /// </param>
        /// <returns type="Promise" />

        var args = sliceDeferred.call(arguments, 0),
			i = 0,
			length = args.length,
			pValues = new Array(length),
			count = length,
			pCount = length,
			deferred = length <= 1 && firstParam && jQuery.isFunction(firstParam.promise) ?
            firstParam :
				jQuery.Deferred(),
			promise = deferred.promise();
        function resolveFunc(i) {
            return function (value) {
                args[i] = arguments.length > 1 ? sliceDeferred.call(arguments, 0) : value;
                if (!(--count)) {
                    deferred.resolveWith(deferred, args);
                }
            };
        }
        function progressFunc(i) {
            return function (value) {
                pValues[i] = arguments.length > 1 ? sliceDeferred.call(arguments, 0) : value;
                deferred.notifyWith(promise, pValues);
            };
        }
        if (length > 1) {
            for (; i < length; i++) {
                if (args[i] && args[i].promise && jQuery.isFunction(args[i].promise)) {
                    args[i].promise().then(resolveFunc(i), deferred.reject, progressFunc(i));
                } else {
                    --count;
                }
            }
            if (!count) {
                deferred.resolveWith(deferred, args);
            }
        } else if (deferred !== firstParam) {
            deferred.resolveWith(deferred, length ? [firstParam] : []);
        }
        return promise;
    };
    jQuery.Event.prototype.isDefaultPrevented = function returnFalse() {
        /// <summary>
        ///     根据事件对象中是否调用过 event.preventDefault() 方法，返回一个布尔值。
        /// </summary>
        /// <returns type="Boolean" />

        return false;
    };
    jQuery.Event.prototype.isImmediatePropagationStopped = function returnFalse() {
        /// <summary>
        ///     根据事件对象中是否调用过 event.stopImmediatePropagation() 方法,返回一个布尔值
        /// </summary>
        /// <returns type="Boolean" />

        return false;
    };
    jQuery.Event.prototype.isPropagationStopped = function returnFalse() {
        /// <summary>
        ///     根据事件对象中是否调用过 event.stopPropagation() 方法，返回一个布尔值。
        /// </summary>
        /// <returns type="Boolean" />

        return false;
    };
    jQuery.Event.prototype.preventDefault = function () {
        /// <summary>
        ///     阻止默认的事件动作被触发。
        /// </summary>
        /// <returns type="undefined" />

        this.isDefaultPrevented = returnTrue;

        var e = this.originalEvent;
        if (!e) {
            return;
        }

        // if preventDefault exists run it on the original event
        if (e.preventDefault) {
            e.preventDefault();

            // otherwise set the returnValue property of the original event to false (IE)
        } else {
            e.returnValue = false;
        }
    };
    jQuery.Event.prototype.stopImmediatePropagation = function () {
        /// <summary>
        ///     阻止剩余的事件处理函数的执行，并且防止事件冒泡到 DOM 树上。
        /// </summary>

        this.isImmediatePropagationStopped = returnTrue;
        this.stopPropagation();
    };
    jQuery.Event.prototype.stopPropagation = function () {
        /// <summary>
        ///     防止事件冒泡到 DOM 树上，也就是不触发任何父元素上的事件处理函数。
        /// </summary>

        this.isPropagationStopped = returnTrue;

        var e = this.originalEvent;
        if (!e) {
            return;
        }
        // if stopPropagation exists run it on the original event
        if (e.stopPropagation) {
            e.stopPropagation();
        }
        // otherwise set the cancelBubble property of the original event to true (IE)
        e.cancelBubble = true;
    };
    jQuery.prototype._toggle = function (fn) {

        // Save reference to arguments for access in closure
        var args = arguments,
			guid = fn.guid || jQuery.guid++,
			i = 0,
			toggler = function (event) {
			    // Figure out which function to execute
			    var lastToggle = (jQuery._data(this, "lastToggle" + fn.guid) || 0) % i;
			    jQuery._data(this, "lastToggle" + fn.guid, lastToggle + 1);

			    // Make sure that clicks stop
			    event.preventDefault();

			    // and execute the function
			    return args[lastToggle].apply(this, arguments) || false;
			};

        // link all the functions, so any of them can unbind this click handler
        toggler.guid = guid;
        while (i < args.length) {
            args[i++].guid = guid;
        }

        return this.click(toggler);
    };
    jQuery.prototype.add = function (selector, context) {
        /// <summary>
        ///     添加元素到匹配的元素集合。
        ///     &#10;1 - add(selector)
        ///     &#10;2 - add(elements)
        ///     &#10;3 - add(html)
        ///     &#10;4 - add(jQuery object)
        ///     &#10;5 - add(selector, context)
        /// </summary>
        /// <param name="selector" type="String">
        ///     一个用于匹配元素的选择器字符串
        /// </param>
        /// <param name="context" domElement="true">
        ///     对指定的范围内添加一些根元素
        /// </param>
        /// <returns type="jQuery" />

        var set = typeof selector === "string" ?
				jQuery(selector, context) :
				jQuery.makeArray(selector && selector.nodeType ? [selector] : selector),
			all = jQuery.merge(this.get(), set);

        return this.pushStack(isDisconnected(set[0]) || isDisconnected(all[0]) ?
            all :
			jQuery.unique(all));
    };
    jQuery.prototype.addClass = function (value) {
        /// <summary>
        ///     为每个匹配的元素添加指定的类名
        ///     &#10;1 - addClass(className)
        ///     &#10;2 - addClass(function(index, currentClass))
        /// </summary>
        /// <param name="value" type="String">
        ///     一个或多个 CSS 样式名，将会被添加到每个匹配元素的 class 属性中。 
        /// </param>
        /// <returns type="jQuery" />

        var classNames, i, l, elem,
			setClass, c, cl;

        if (jQuery.isFunction(value)) {
            return this.each(function (j) {
                jQuery(this).addClass(value.call(this, j, this.className));
            });
        }

        if (value && typeof value === "string") {
            classNames = value.split(rspace);

            for (i = 0, l = this.length; i < l; i++) {
                elem = this[i];

                if (elem.nodeType === 1) {
                    if (!elem.className && classNames.length === 1) {
                        elem.className = value;

                    } else {
                        setClass = " " + elem.className + " ";

                        for (c = 0, cl = classNames.length; c < cl; c++) {
                            if (!~setClass.indexOf(" " + classNames[c] + " ")) {
                                setClass += classNames[c] + " ";
                            }
                        }
                        elem.className = jQuery.trim(setClass);
                    }
                }
            }
        }

        return this;
    };
    jQuery.prototype.after = function () {
        /// <summary>
        ///     在每个匹配元素的后面，插入指定的内容，作为其兄弟节点。
        ///     &#10;1 - after(content, content)
        ///     &#10;2 - after(function(index))
        /// </summary>
        /// <param name="" type="jQuery">
        ///      待插入的内容，可以是选择器, 元素, HTML 字符串, 或 jQuery 对象。待插入的内容将会被插入到每个匹配元素的后面。
        /// </param>
        /// <param name="" type="jQuery">
        ///      可选参数，可选参数，表示将要插入到匹配元素后面的内容。可以是一个或多个附加的 DOM 元素, 元素数组, HTML 字符串, 或 jQuery 对象。
        /// </param>
        /// <returns type="jQuery" />

        if (this[0] && this[0].parentNode) {
            return this.domManip(arguments, false, function (elem) {
                this.parentNode.insertBefore(elem, this.nextSibling);
            });
        } else if (arguments.length) {
            var set = this.pushStack(this, "after", arguments);
            set.push.apply(set, jQuery.clean(arguments));
            return set;
        }
    };
    jQuery.prototype.ajaxComplete = function (f) {
        /// <summary>
        ///     注册一个事件处理函数，这个函数会在 Ajax 请求完成时被调用
        /// </summary>
        /// <param name="f" type="Function">
        ///     将要被调用的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(o, f);
    };
    jQuery.prototype.ajaxError = function (f) {
        /// <summary>
        ///     注册一个事件处理函数，这个函数会在 Ajax 请求出错时被调用
        /// </summary>
        /// <param name="f" type="Function">
        ///     将要被调用的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(o, f);
    };
    jQuery.prototype.ajaxSend = function (f) {
        /// <summary>
        ///     注册一个事件处理函数，这个函数会在 Ajax 请求之前被调用
        /// </summary>
        /// <param name="f" type="Function">
        ///     将要被调用的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(o, f);
    };
    jQuery.prototype.ajaxStart = function (f) {
        /// <summary>
        ///     注册一个事件处理函数，这个函数会在第一个 Ajax 请求开始时被调用
        /// </summary>
        /// <param name="f" type="Function">
        ///      将要被调用的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(o, f);
    };
    jQuery.prototype.ajaxStop = function (f) {
        /// <summary>
        ///     注册一个事件处理函数，这个函数会在所有的 Ajax 请求都完成时被调用
        /// </summary>
        /// <param name="f" type="Function">
        ///      将要被调用的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(o, f);
    };
    jQuery.prototype.ajaxSuccess = function (f) {
        /// <summary>
        ///     注册一个事件处理函数，这个函数会在 Ajax 请求成功完成时被调用
        /// </summary>
        /// <param name="f" type="Function">
        ///      将要被调用的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(o, f);
    };
    jQuery.prototype.andSelf = function () {
        /// <summary>
        ///     将前一个元素集合插入到当前集合的栈顶
        /// </summary>
        /// <returns type="jQuery" />

        return this.add(this.prevObject);
    };
    jQuery.prototype.animate = function (prop, speed, easing, callback) {
        /// <summary>
        ///     根据一组 CSS 属性，执行自定义动画
        ///     &#10;1 - animate(properties, duration, easing, complete)
        ///     &#10;2 - animate(properties, options)
        /// </summary>
        /// <param name="prop" type="Object">
        ///     用于设置动画的 CSS 映射
        /// </param>
        /// <param name="speed" type="Number">
        ///     可选参数，字符串("slow"或 "fast")或表示动画时长的毫秒数值
        /// </param>
        /// <param name="easing" type="String">
        ///     可选参数，要使用的缓冲效果的名称
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        var optall = jQuery.speed(speed, easing, callback);

        if (jQuery.isEmptyObject(prop)) {
            return this.each(optall.complete, [false]);
        }

        // Do not change referenced properties as per-property easing will be lost
        prop = jQuery.extend({}, prop);

        function doAnimation() {
            // XXX 'this' does not always have a nodeName when running the
            // test suite

            if (optall.queue === false) {
                jQuery._mark(this);
            }

            var opt = jQuery.extend({}, optall),
				isElement = this.nodeType === 1,
				hidden = isElement && jQuery(this).is(":hidden"),
				name, val, p, e, hooks, replace,
				parts, start, end, unit,
				method;

            // will store per property easing and be used to determine when an animation is complete
            opt.animatedProperties = {};

            // first pass over propertys to expand / normalize
            for (p in prop) {
                name = jQuery.camelCase(p);
                if (p !== name) {
                    prop[name] = prop[p];
                    delete prop[p];
                }

                if ((hooks = jQuery.cssHooks[name]) && "expand" in hooks) {
                    replace = hooks.expand(prop[name]);
                    delete prop[name];

                    // not quite $.extend, this wont overwrite keys already present.
                    // also - reusing 'p' from above because we have the correct "name"
                    for (p in replace) {
                        if (!(p in prop)) {
                            prop[p] = replace[p];
                        }
                    }
                }
            }

            for (name in prop) {
                val = prop[name];
                // easing resolution: per property > opt.specialEasing > opt.easing > 'swing' (default)
                if (jQuery.isArray(val)) {
                    opt.animatedProperties[name] = val[1];
                    val = prop[name] = val[0];
                } else {
                    opt.animatedProperties[name] = opt.specialEasing && opt.specialEasing[name] || opt.easing || 'swing';
                }

                if (val === "hide" && hidden || val === "show" && !hidden) {
                    return opt.complete.call(this);
                }

                if (isElement && (name === "height" || name === "width")) {
                    // Make sure that nothing sneaks out
                    // Record all 3 overflow attributes because IE does not
                    // change the overflow attribute when overflowX and
                    // overflowY are set to the same value
                    opt.overflow = [this.style.overflow, this.style.overflowX, this.style.overflowY];

                    // Set display property to inline-block for height/width
                    // animations on inline elements that are having width/height animated
                    if (jQuery.css(this, "display") === "inline" &&
							jQuery.css(this, "float") === "none") {

                        // inline-level elements accept inline-block;
                        // block-level elements need to be inline with layout
							    if (!jQuery.support.inlineBlockNeedsLayout || defaultDisplay(this.nodeName) === "inline") {
							        this.style.display = "inline-block";

							    } else {
							        this.style.zoom = 1;
							    }
							}
                }
            }

            if (opt.overflow != null) {
                this.style.overflow = "hidden";
            }

            for (p in prop) {
                e = new jQuery.fx(this, opt, p);
                val = prop[p];

                if (rfxtypes.test(val)) {

                    // Tracks whether to show or hide based on private
                    // data attached to the element
                    method = jQuery._data(this, "toggle" + p) || (val === "toggle" ? hidden ? "show" : "hide" : 0);
                    if (method) {
                        jQuery._data(this, "toggle" + p, method === "show" ? "hide" : "show");
                        e[method]();
                    } else {
                        e[val]();
                    }

                } else {
                    parts = rfxnum.exec(val);
                    start = e.cur();

                    if (parts) {
                        end = parseFloat(parts[2]);
                        unit = parts[3] || (jQuery.cssNumber[p] ? "" : "px");

                        // We need to compute starting value
                        if (unit !== "px") {
                            jQuery.style(this, p, (end || 1) + unit);
                            start = ((end || 1) / e.cur()) * start;
                            jQuery.style(this, p, start + unit);
                        }

                        // If a +=/-= token was provided, we're doing a relative animation
                        if (parts[1]) {
                            end = ((parts[1] === "-=" ? -1 : 1) * end) + start;
                        }

                        e.custom(start, end, unit);

                    } else {
                        e.custom(start, val, "");
                    }
                }
            }

            // For JS strict compliance
            return true;
        }

        return optall.queue === false ?
			this.each(doAnimation) :
			this.queue(optall.queue, doAnimation);
    };
    jQuery.prototype.append = function () {
        /// <summary>
        ///     在每个匹配元素内的结尾处插入指定的内容。
        ///     &#10;1 - append(content, content)
        ///     &#10;2 - append(function(index, html))
        /// </summary>
        /// <param name="" type="jQuery">
        ///     将要插入到匹配元素结尾的 DOM 元素, HTML 字符串,或 jQuery 对象
        /// </param>
        /// <param name="" type="jQuery">
        ///      可选参数，将要插入到匹配元素结尾的，一个或多个附加的 DOM 元素, 元素数组, HTML 字符串, 或 jQuery 对象
        /// </param>
        /// <returns type="jQuery" />

        return this.domManip(arguments, true, function (elem) {
            if (this.nodeType === 1) {
                this.appendChild(elem);
            }
        });
    };
    jQuery.prototype.appendTo = function (selector) {
        /// <summary>
        ///     将指定的内容，插入到每个匹配元素内的结尾处
        /// </summary>
        /// <param name="selector" type="jQuery">
        ///      用于插入到匹配元素中的选择器, 元素, HTML 字符串, 或 jQuery 对象
        /// </param>
        /// <returns type="jQuery" />

        var ret = [],
			insert = jQuery(selector),
			parent = this.length === 1 && this[0].parentNode;

        if (parent && parent.nodeType === 11 && parent.childNodes.length === 1 && insert.length === 1) {
            insert[original](this[0]);
            return this;

        } else {
            for (var i = 0, l = insert.length; i < l; i++) {
                var elems = (i > 0 ? this.clone(true) : this).get();
                jQuery(insert[i])[original](elems);
                ret = ret.concat(elems);
            }

            return this.pushStack(ret, name, insert.selector);
        }
    };
    jQuery.prototype.attr = function (name, value) {
        /// <summary>
        ///     1: 取得所有匹配的元素中，第一个元素的属性值
        ///     &#10;    1.1 - attr(attributeName)
        ///     &#10;2: 为所有匹配的元素，设置一个或多个属性值
        ///     &#10;    2.1 - attr(attributeName, value)
        ///     &#10;    2.2 - attr(map)
        ///     &#10;    2.3 - attr(attributeName, function(index, attr))
        /// </summary>
        /// <param name="name" type="String">
        ///      将要设置的属性名
        /// </param>
        /// <param name="value" type="Number">
        ///     将要设置的属性值
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, jQuery.attr, name, value, arguments.length > 1);
    };
    jQuery.prototype.before = function () {
        /// <summary>
        ///     在每个匹配元素的前面，插入指定的内容，作为其兄弟节点
        ///     &#10;1 - before(content, content)
        ///     &#10;2 - before(function)
        /// </summary>
        /// <param name="" type="jQuery">
        ///     待插入的内容，可以是选择器, 元素, HTML 字符串, 或 jQuery 对象。待插入的内容将会被插入到每个匹配元素的前面。 
        /// </param>
        /// <param name="" type="jQuery">
        ///     可选参数，可选参数，可选参数，表示将要插入到匹配元素前面的内容。可以是一个或多个附加的 DOM 元素, 元素数组, HTML 字符串, 或 jQuery 对象。
        /// </param>
        /// <returns type="jQuery" />

        if (this[0] && this[0].parentNode) {
            return this.domManip(arguments, false, function (elem) {
                this.parentNode.insertBefore(elem, this);
            });
        } else if (arguments.length) {
            var set = jQuery.clean(arguments);
            set.push.apply(set, this.toArray());
            return this.pushStack(set, "before", arguments);
        }
    };
    jQuery.prototype.bind = function (types, data, fn) {
        /// <summary>
        ///     为元素绑定事件
        ///     &#10;1 - bind(eventType, eventData, handler(eventObject))
        ///     &#10;2 - bind(eventType, eventData, preventBubble)
        ///     &#10;3 - bind(events)
        /// </summary>
        /// <param name="types" type="String">
        ///     包含一个或多个 DOM 事件类型的字符串。例如，"click"， "submit," 或自定义事件名
        /// </param>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(types, null, data, fn);
    };
    jQuery.prototype.blur = function (data, fn) {
        /// <summary>
        ///     为 JavaScript 的 "blur" 事件绑定一个处理函数，或者触发元素上的该事件
        ///     &#10;1 - blur(handler(eventObject))
        ///     &#10;2 - blur(eventData, handler(eventObject))
        ///     &#10;3 - blur()
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.change = function (data, fn) {
        /// <summary>
        ///     为JavaScript 的 "change" 事件绑定一个处理函数，或者触发元素上的该事件
        ///     &#10;1 - change(handler(eventObject))
        ///     &#10;2 - change(eventData, handler(eventObject))
        ///     &#10;3 - change()
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///      每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.children = function (until, selector) {
        /// <summary>
        ///     取得匹配元素集合中每个元素的子元素，也可以通过一个选择器进行过滤
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.clearQueue = function (type) {
        /// <summary>
        ///     清空对象上的队列中所有尚未执行的项目
        /// </summary>
        /// <param name="type" type="String">
        ///     可选参数，包含队列名称的字符串，默认值是动画效果队列 fx
        /// </param>
        /// <returns type="jQuery" />

        return this.queue(type || "fx", []);
    };
    jQuery.prototype.click = function (data, fn) {
        /// <summary>
        ///     为 JavaScript 的 "click" 事件绑定一个处理函数，或者触发元素上的该事件
        ///     &#10;1 - click(handler(eventObject))
        ///     &#10;2 - click(eventData, handler(eventObject))
        ///     &#10;3 - click()
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.clone = function (dataAndEvents, deepDataAndEvents) {
        /// <summary>
        ///     对匹配的元素进行深层拷贝
        ///     &#10;1 - clone(withDataAndEvents)
        ///     &#10;2 - clone(withDataAndEvents, deepWithDataAndEvents)
        /// </summary>
        /// <param name="dataAndEvents" type="Boolean">
        ///     可选参数，默认值:'false'布尔值，表示是否也拷贝元素上的事件和数据。默认值是 false。* 在 jQuery 1.5.0 中，该默认值被设置成了 true，但这样做似乎并不太合适。所以从 1.5.1 开始，该默认值恢复成了 false。
        /// </param>
        /// <param name="deepDataAndEvents" type="Boolean">
        ///     可选参数，默认值:'value of withDataAndEvents'布尔值，表示是否也拷贝元素及该元素上所有子元素的事件和数据。默认情况下，该值与 withDataAndEvents 参数的值是一样的。(也就是说，默认值是 false)。 
        /// </param>
        /// <returns type="jQuery" />

        dataAndEvents = dataAndEvents == null ? false : dataAndEvents;
        deepDataAndEvents = deepDataAndEvents == null ? dataAndEvents : deepDataAndEvents;

        return this.map(function () {
            return jQuery.clone(this, dataAndEvents, deepDataAndEvents);
        });
    };
    jQuery.prototype.closest = function (selectors, context) {
        /// <summary>
        ///     1: 取得与选择器相匹配的第一个元素，从当前元素开始，在 DOM 树中向上查找
        ///     &#10;    1.1 - closest(selector)
        ///     &#10;    1.2 - closest(selector, context)
        ///     &#10;    1.3 - closest(jQuery object)
        ///     &#10;    1.4 - closest(element)
        ///     &#10;2: 以数组的形式返回与选择器相匹配的所有元素，从当前元素开始，在 DOM 树中向上遍历
        ///     &#10;    2.1 - closest(selectors, context)
        /// </summary>
        /// <param name="selectors" type="String">
        ///     选择器表达式数组或字符串，用于查找匹配的元素（也可以是 jQuery 对象）。
        /// </param>
        /// <param name="context" domElement="true">
        ///     可选参数，用于查找可能匹配到的 DOM 元素。如果不提供 context 参数，那么会使用 jQuery 集合的 context。
        /// </param>
        /// <returns type="jQuery" />

        var ret = [], i, l, cur = this[0];

        // Array (deprecated as of jQuery 1.7)
        if (jQuery.isArray(selectors)) {
            var level = 1;

            while (cur && cur.ownerDocument && cur !== context) {
                for (i = 0; i < selectors.length; i++) {

                    if (jQuery(cur).is(selectors[i])) {
                        ret.push({ selector: selectors[i], elem: cur, level: level });
                    }
                }

                cur = cur.parentNode;
                level++;
            }

            return ret;
        }

        // String
        var pos = POS.test(selectors) || typeof selectors !== "string" ?
				jQuery(selectors, context || this.context) :
				0;

        for (i = 0, l = this.length; i < l; i++) {
            cur = this[i];

            while (cur) {
                if (pos ? pos.index(cur) > -1 : jQuery.find.matchesSelector(cur, selectors)) {
                    ret.push(cur);
                    break;

                } else {
                    cur = cur.parentNode;
                    if (!cur || !cur.ownerDocument || cur === context || cur.nodeType === 11) {
                        break;
                    }
                }
            }
        }

        ret = ret.length > 1 ? jQuery.unique(ret) : ret;

        return this.pushStack(ret, "closest", selectors);
    };
    jQuery.prototype.constructor = function (selector, context) {

        // The jQuery object is actually just the init constructor 'enhanced'
        return new jQuery.fn.init(selector, context, rootjQuery);
    };
    jQuery.prototype.contents = function (until, selector) {
        /// <summary>
        ///     取得匹配元素中的每个元素的子元素，包括文本和注释节点
        /// </summary>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.contextmenu = function (data, fn) {

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.css = function (name, value) {
        /// <summary>
        ///     1: 取得第一个匹配元素的 CSS 属性值。
        ///     &#10;    1.1 - css(propertyName)
        ///     &#10;2: 为匹配的元素设置一个或多个 CSS 属性
        ///     &#10;    2.1 - css(propertyName, value)
        ///     &#10;    2.2 - css(propertyName, function(index, value))
        ///     &#10;    2.3 - css(map)
        /// </summary>
        /// <param name="name" type="String">
        ///     CSS 属性名
        /// </param>
        /// <param name="value" type="Number">
        ///     属性值
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (elem, name, value) {
            return value !== undefined ?
			jQuery.style(elem, name, value) :
			jQuery.css(elem, name);
        }, name, value, arguments.length > 1);
    };
    jQuery.prototype.data = function (key, value) {
        /// <summary>
        ///     1: 在匹配的元素上随心所欲的存放数据.
        ///     &#10;    1.1 - data(key, value)
        ///     &#10;    1.2 - data(obj)
        ///     &#10;2: 返回 jQuery 对象集合中第一个元素上储存的数据，这个数据是先前用data(name, value)设定的
        ///     &#10;    2.1 - data(key)
        ///     &#10;    2.2 - data()
        /// </summary>
        /// <param name="key" type="String">
        ///     一个字符串键，代表将要被存储的数据
        /// </param>
        /// <param name="value" type="Object">
        ///     新的数据值；可以是任何 Javascript 类型，包括数组和对象
        /// </param>
        /// <returns type="jQuery" />

        var parts, part, attr, name, l,
			elem = this[0],
			i = 0,
			data = null;

        // Gets all values
        if (key === undefined) {
            if (this.length) {
                data = jQuery.data(elem);

                if (elem.nodeType === 1 && !jQuery._data(elem, "parsedAttrs")) {
                    attr = elem.attributes;
                    for (l = attr.length; i < l; i++) {
                        name = attr[i].name;

                        if (name.indexOf("data-") === 0) {
                            name = jQuery.camelCase(name.substring(5));

                            dataAttr(elem, name, data[name]);
                        }
                    }
                    jQuery._data(elem, "parsedAttrs", true);
                }
            }

            return data;
        }

        // Sets multiple values
        if (typeof key === "object") {
            return this.each(function () {
                jQuery.data(this, key);
            });
        }

        parts = key.split(".", 2);
        parts[1] = parts[1] ? "." + parts[1] : "";
        part = parts[1] + "!";

        return jQuery.access(this, function (value) {

            if (value === undefined) {
                data = this.triggerHandler("getData" + part, [parts[0]]);

                // Try to fetch any internally stored data first
                if (data === undefined && elem) {
                    data = jQuery.data(elem, key);
                    data = dataAttr(elem, key, data);
                }

                return data === undefined && parts[1] ?
					this.data(parts[0]) :
					data;
            }

            parts[1] = value;
            this.each(function () {
                var self = jQuery(this);

                self.triggerHandler("setData" + part, parts);
                jQuery.data(this, key, value);
                self.triggerHandler("changeData" + part, parts);
            });
        }, null, value, arguments.length > 1, null, false);
    };
    jQuery.prototype.dblclick = function (data, fn) {
        /// <summary>
        ///     为 JavaScript 的 "dblclick" 事件绑定一个处理函数，或者触发元素上的该事件
        ///     &#10;1 - dblclick(handler(eventObject))
        ///     &#10;2 - dblclick(eventData, handler(eventObject))
        ///     &#10;3 - dblclick()
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.delay = function (time, type) {
        /// <summary>
        ///     设置一个延时来推迟执行队列中的项目。
        /// </summary>
        /// <param name="time" type="Number">
        ///     以毫秒为单位的整数，用于设定队列中的下一项目推迟执行的时间
        /// </param>
        /// <param name="type" type="String">
        ///     可选参数，包含队列名称的字符串，默认值是动画效果队列 fx
        /// </param>
        /// <returns type="jQuery" />

        time = jQuery.fx ? jQuery.fx.speeds[time] || time : time;
        type = type || "fx";

        return this.queue(type, function (next, hooks) {
            var timeout = setTimeout(next, time);
            hooks.stop = function () {
                clearTimeout(timeout);
            };
        });
    };
    jQuery.prototype.delegate = function (selector, types, data, fn) {
        /// <summary>
        ///     为所有与选择器匹配的元素的一个或多个事件添加事件处理。基于一个指定的根元素的子集，匹配的元素包括那些目前已经匹配到的元素，也包括那些今后可能匹配到的元素。
        ///     &#10;1 - delegate(selector, eventType, handler(eventObject))
        ///     &#10;2 - delegate(selector, eventType, eventData, handler(eventObject))
        ///     &#10;3 - delegate(selector, events)
        /// </summary>
        /// <param name="selector" type="String">
        ///     触发事件的元素选择器
        /// </param>
        /// <param name="types" type="String">
        ///     含有 JavaScript 事件类型的字符串，字符串间使用空格分隔，例如："click" , "keydown," 或自定义事件名称。
        /// </param>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.on(types, selector, data, fn);
    };
    jQuery.prototype.dequeue = function (type) {
        /// <summary>
        ///     执行匹配元素上函数队列中的下一个函数
        /// </summary>
        /// <param name="type" type="String">
        ///      可选参数，包含队列名称的字符串，默认值是动画效果队列 fx
        /// </param>
        /// <returns type="jQuery" />

        return this.each(function () {
            jQuery.dequeue(this, type);
        });
    };
    jQuery.prototype.detach = function (selector) {
        /// <summary>
        ///     从 DOM 中移除匹配的元素，但保留移除元素上的事件及 jQuery 数据
        /// </summary>
        /// <param name="selector" type="String">
        ///     可选参数，选择器表达式，用于过滤出将要被移除的元素
        /// </param>
        /// <returns type="jQuery" />

        return this.remove(selector, true);
    };
    jQuery.prototype.die = function (types, fn) {
        /// <summary>
        ///     1: 从元素上移除所有之前通过 .live() 添加的事件处理。
        ///     &#10;    1.1 - die()
        ///     &#10;2: 从元素上移除所有之前通过 .live() 添加的事件处理。
        ///     &#10;    2.1 - die(eventType, handler)
        ///     &#10;    2.2 - die(eventTypes)
        /// </summary>
        /// <param name="types" type="String">
        ///     包含 JavaScript 事件类型的字符串。例如 click 或 keydown
        /// </param>
        /// <param name="fn" type="String">
        ///     可选参数，不再需要执行的函数
        /// </param>
        /// <returns type="jQuery" />

        jQuery(this.context).off(types, this.selector || "**", fn);
        return this;
    };
    jQuery.prototype.domManip = function (args, table, callback) {

        var results, first, fragment, parent,
			value = args[0],
			scripts = [];

        // We can't cloneNode fragments that contain checked, in WebKit
        if (!jQuery.support.checkClone && arguments.length === 3 && typeof value === "string" && rchecked.test(value)) {
            return this.each(function () {
                jQuery(this).domManip(args, table, callback, true);
            });
        }

        if (jQuery.isFunction(value)) {
            return this.each(function (i) {
                var self = jQuery(this);
                args[0] = value.call(this, i, table ? self.html() : undefined);
                self.domManip(args, table, callback);
            });
        }

        if (this[0]) {
            parent = value && value.parentNode;

            // If we're in a fragment, just use that instead of building a new one
            if (jQuery.support.parentNode && parent && parent.nodeType === 11 && parent.childNodes.length === this.length) {
                results = { fragment: parent };

            } else {
                results = jQuery.buildFragment(args, this, scripts);
            }

            fragment = results.fragment;

            if (fragment.childNodes.length === 1) {
                first = fragment = fragment.firstChild;
            } else {
                first = fragment.firstChild;
            }

            if (first) {
                table = table && jQuery.nodeName(first, "tr");

                for (var i = 0, l = this.length, lastIndex = l - 1; i < l; i++) {
                    callback.call(
						table ?
							root(this[i], first) :
							this[i],
						// Make sure that we do not leak memory by inadvertently discarding
						// the original fragment (which might have attached data) instead of
						// using it; in addition, use the original fragment object for the last
						// item instead of first because it can end up being emptied incorrectly
						// in certain situations (Bug #8070).
						// Fragments from the fragment cache must always be cloned and never used
						// in place.
						results.cacheable || (l > 1 && i < lastIndex) ?
							jQuery.clone(fragment, true, true) :
							fragment
					);
                }
            }

            if (scripts.length) {
                jQuery.each(scripts, function (i, elem) {
                    if (elem.src) {
                        jQuery.ajax({
                            type: "GET",
                            global: false,
                            url: elem.src,
                            async: false,
                            dataType: "script"
                        });
                    } else {
                        jQuery.globalEval((elem.text || elem.textContent || elem.innerHTML || "").replace(rcleanScript, "/*$0*/"));
                    }

                    if (elem.parentNode) {
                        elem.parentNode.removeChild(elem);
                    }
                });
            }
        }

        return this;
    };
    jQuery.prototype.each = function (callback, args) {
        /// <summary>
        ///     迭代一个 jQuery 对象，为每个匹配的元素执行函数
        /// </summary>
        /// <param name="callback" type="Function">
        ///      为每个匹配元素执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.each(this, callback, args);
    };
    jQuery.prototype.empty = function () {
        /// <summary>
        ///     从DOM中移除所有节点的子节点。
        /// </summary>
        /// <returns type="jQuery" />

        for (var i = 0, elem; (elem = this[i]) != null; i++) {
            // Remove element nodes and prevent memory leaks
            if (elem.nodeType === 1) {
                jQuery.cleanData(elem.getElementsByTagName("*"));
            }

            // Remove any remaining nodes
            while (elem.firstChild) {
                elem.removeChild(elem.firstChild);
            }
        }

        return this;
    };
    jQuery.prototype.end = function () {
        /// <summary>
        ///     终止在当前链的最新过滤操作，并返回匹配的元素集合为它以前的状态。
        /// </summary>
        /// <returns type="jQuery" />

        return this.prevObject || this.constructor(null);
    };
    jQuery.prototype.eq = function (i) {
        /// <summary>
        ///     选择在匹配的集合中，索引值等于 index 的元素
        ///     &#10;1 - eq(index)
        ///     &#10;2 - eq(-index)
        /// </summary>
        /// <param name="i" type="Number">
        ///    匹配元素用的索引值。索引值从 0 开始计数
        /// </param>
        /// <returns type="jQuery" />

        i = +i;
        return i === -1 ?
			this.slice(i) :
			this.slice(i, i + 1);
    };
    jQuery.prototype.error = function (data, fn) {
        /// <summary>
        ///     为 JavaScript 的 "error" 事件绑定一个处理函数
        ///     &#10;1 - error(handler(eventObject))
        ///     &#10;2 - error(eventData, handler(eventObject))
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.extend = function () {

        var options, name, src, copy, copyIsArray, clone,
		target = arguments[0] || {},
		i = 1,
		length = arguments.length,
		deep = false;

        // Handle a deep copy situation
        if (typeof target === "boolean") {
            deep = target;
            target = arguments[1] || {};
            // skip the boolean and the target
            i = 2;
        }

        // Handle case when target is a string or something (possible in deep copy)
        if (typeof target !== "object" && !jQuery.isFunction(target)) {
            target = {};
        }

        // extend jQuery itself if only one argument is passed
        if (length === i) {
            target = this;
            --i;
        }

        for (; i < length; i++) {
            // Only deal with non-null/undefined values
            if ((options = arguments[i]) != null) {
                // Extend the base object
                for (name in options) {
                    src = target[name];
                    copy = options[name];

                    // Prevent never-ending loop
                    if (target === copy) {
                        continue;
                    }

                    // Recurse if we're merging plain objects or arrays
                    if (deep && copy && (jQuery.isPlainObject(copy) || (copyIsArray = jQuery.isArray(copy)))) {
                        if (copyIsArray) {
                            copyIsArray = false;
                            clone = src && jQuery.isArray(src) ? src : [];

                        } else {
                            clone = src && jQuery.isPlainObject(src) ? src : {};
                        }

                        // Never move original objects, clone them
                        target[name] = jQuery.extend(deep, clone, copy);

                        // Don't bring in undefined values
                    } else if (copy !== undefined) {
                        target[name] = copy;
                    }
                }
            }
        }

        // Return the modified object
        return target;
    };
    jQuery.prototype.fadeIn = function (speed, easing, callback) {
        /// <summary>
        ///     通过淡入的方式显示匹配元素
        ///     &#10;1 - fadeIn(duration, callback)
        ///     &#10;2 - fadeIn(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     一个字符串或者数字决定动画将运行多久
        /// </param>
        /// <param name="easing" type="String">
        ///     一个用来表示使用哪个缓冲函数来过渡的字符串
        /// </param>
        /// <param name="callback" type="Function">
        ///     在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.animate(props, speed, easing, callback);
    };
    jQuery.prototype.fadeOut = function (speed, easing, callback) {
        /// <summary>
        ///     通过淡出的方式显示匹配元素
        ///     &#10;1 - fadeOut(duration, callback)
        ///     &#10;2 - fadeOut(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     一个字符串或者数字决定动画将运行多久
        /// </param>
        /// <param name="easing" type="String">
        ///     一个用来表示使用哪个缓冲函数来过渡的字符串
        /// </param>
        /// <param name="callback" type="Function">
        ///     在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.animate(props, speed, easing, callback);
    };
    jQuery.prototype.fadeTo = function (speed, to, easing, callback) {
        /// <summary>
        ///     调整匹配元素的透明度
        ///     &#10;1 - fadeTo(duration, opacity, callback)
        ///     &#10;2 - fadeTo(duration, opacity, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     一个字符串或者数字决定动画将运行多久
        /// </param>
        /// <param name="to" type="Number">
        ///     一个0至1之间表示目标透明度的数字
        /// </param>
        /// <param name="easing" type="String">
        ///     一个用来表示使用哪个缓冲函数来过渡的字符串
        /// </param>
        /// <param name="callback" type="Function">
        ///     在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.filter(":hidden").css("opacity", 0).show().end()
					.animate({ opacity: to }, speed, easing, callback);
    };
    jQuery.prototype.fadeToggle = function (speed, easing, callback) {
        /// <summary>
        ///     通过透明度动画来显示或隐藏匹配的元素
        /// </summary>
        /// <param name="speed" type="Number">
        ///     可选参数，字符串("slow"或 "fast")或表示动画时长的毫秒数值
        /// </param>
        /// <param name="easing" type="String">
        ///     可选参数，要使用的缓冲效果的名称
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.animate(props, speed, easing, callback);
    };
    jQuery.prototype.filter = function (selector) {
        /// <summary>
        ///     筛选出与指定表达式匹配的元素集合
        ///     &#10;1 - filter(selector)
        ///     &#10;2 - filter(function(index))
        ///     &#10;3 - filter(element)
        ///     &#10;4 - filter(jQuery object)
        /// </summary>
        /// <param name="selector" type="String">
        ///     选择器字符串，用于确定到哪个前辈元素时停止匹配
        /// </param>
        /// <returns type="jQuery" />

        return this.pushStack(winnow(this, selector, true), "filter", selector);
    };
    jQuery.prototype.find = function (selector) {
        /// <summary>
        ///     获得当前元素匹配集合中每个元素的后代，选择性筛选的选择器
        ///     &#10;1 - find(selector)
        ///     &#10;2 - find(jQuery object)
        ///     &#10;3 - find(element)
        /// </summary>
        /// <param name="selector" type="String">
        ///     一个用于匹配元素的选择器字符串
        /// </param>
        /// <returns type="jQuery" />

        var self = this,
			i, l;

        if (typeof selector !== "string") {
            return jQuery(selector).filter(function () {
                for (i = 0, l = self.length; i < l; i++) {
                    if (jQuery.contains(self[i], this)) {
                        return true;
                    }
                }
            });
        }

        var ret = this.pushStack("", "find", selector),
			length, n, r;

        for (i = 0, l = this.length; i < l; i++) {
            length = ret.length;
            jQuery.find(selector, this[i], ret);

            if (i > 0) {
                // Make sure that the results are unique
                for (n = length; n < ret.length; n++) {
                    for (r = 0; r < length; r++) {
                        if (ret[r] === ret[n]) {
                            ret.splice(n--, 1);
                            break;
                        }
                    }
                }
            }
        }

        return ret;
    };
    jQuery.prototype.first = function () {
        /// <summary>
        ///     获取元素集合中第一个元素
        /// </summary>
        /// <returns type="jQuery" />

        return this.eq(0);
    };
    jQuery.prototype.focus = function (data, fn) {
        /// <summary>
        ///     为 "focus" 事件绑定一个处理函数，或者触发元素上的 "focus" 事件
        ///     &#10;1 - focus(handler(eventObject))
        ///     &#10;2 - focus(eventData, handler(eventObject))
        ///     &#10;3 - focus()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.focusin = function (data, fn) {
        /// <summary>
        ///     将一个事件函数绑定到"focusin" 事件
        ///     &#10;1 - focusin(handler(eventObject))
        ///     &#10;2 - focusin(eventData, handler(eventObject))
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.focusout = function (data, fn) {
        /// <summary>
        ///     将一个事件函数绑定到"focusout" 事件
        ///     &#10;1 - focusout(handler(eventObject))
        ///     &#10;2 - focusout(eventData, handler(eventObject))
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.get = function (num) {
        /// <summary>
        ///     获取 jQuery 对象对应的 DOM 元素
        /// </summary>
        /// <param name="num" type="Number">
        ///     可选参数，从 0 开始计数的索引，用于确定获取哪个元素
        /// </param>
        /// <returns type="Array" />

        return num == null ?

			// Return a 'clean' array
			this.toArray() :

			// Return just the object
			(num < 0 ? this[this.length + num] : this[num]);
    };
    jQuery.prototype.has = function (target) {
        /// <summary>
        ///     保留包含特定后代的元素，去掉那些不含有指定后代的元素
        ///     &#10;1 - has(selector)
        ///     &#10;2 - has(contained)
        /// </summary>
        /// <param name="target" type="String">
        ///     一个用于匹配元素的选择器字符串
        /// </param>
        /// <returns type="jQuery" />

        var targets = jQuery(target);
        return this.filter(function () {
            for (var i = 0, l = targets.length; i < l; i++) {
                if (jQuery.contains(this, targets[i])) {
                    return true;
                }
            }
        });
    };
    jQuery.prototype.hasClass = function (selector) {
        /// <summary>
        ///     判断在所有匹配的元素中，是否至少有一个元素包含给定的样式
        /// </summary>
        /// <param name="selector" type="String">
        ///     将要查找的样式名
        /// </param>
        /// <returns type="Boolean" />

        var className = " " + selector + " ",
			i = 0,
			l = this.length;
        for (; i < l; i++) {
            if (this[i].nodeType === 1 && (" " + this[i].className + " ").replace(rclass, " ").indexOf(className) > -1) {
                return true;
            }
        }

        return false;
    };
    jQuery.prototype.height = function (value) {
        /// <summary>
        ///     1: 为匹配的元素集合中获取第一个元素的当前计算高度值
        ///     &#10;    1.1 - height()
        ///     &#10;2: 给每个匹配的元素设置CSS高度
        ///     &#10;    2.1 - height(value)
        ///     &#10;    2.2 - height(function(index, height))
        /// </summary>
        /// <param name="value" type="Number">
        ///     一个正整数代表的像素数,或是整数和一个可选的附加单位（默认是：“px”）(作为一个字符串)
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (elem, type, value) {
            var doc, docElemProp, orig, ret;

            if (jQuery.isWindow(elem)) {
                // 3rd condition allows Nokia support, as it supports the docElem prop but not CSS1Compat
                doc = elem.document;
                docElemProp = doc.documentElement[clientProp];
                return jQuery.support.boxModel && docElemProp ||
					doc.body && doc.body[clientProp] || docElemProp;
            }

            // Get document width or height
            if (elem.nodeType === 9) {
                // Either scroll[Width/Height] or offset[Width/Height], whichever is greater
                doc = elem.documentElement;

                // when a window > document, IE6 reports a offset[Width/Height] > client[Width/Height]
                // so we can't use max, as it'll choose the incorrect offset[Width/Height]
                // instead we use the correct client[Width/Height]
                // support:IE6
                if (doc[clientProp] >= doc[scrollProp]) {
                    return doc[clientProp];
                }

                return Math.max(
					elem.body[scrollProp], doc[scrollProp],
					elem.body[offsetProp], doc[offsetProp]
				);
            }

            // Get width or height on the element
            if (value === undefined) {
                orig = jQuery.css(elem, type);
                ret = parseFloat(orig);
                return jQuery.isNumeric(ret) ? ret : orig;
            }

            // Set the width or height on the element
            jQuery(elem).css(type, value);
        }, type, value, arguments.length, null);
    };
    jQuery.prototype.hide = function (speed, easing, callback) {
        /// <summary>
        ///     隐藏匹配的元素。
        ///     &#10;1 - hide()
        ///     &#10;2 - hide(duration, callback)
        ///     &#10;3 - hide(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     一个字符串或者数字决定动画将运行多久
        /// </param>
        /// <param name="easing" type="String">
        ///     一个字符串，指示该函数使用缓和的过渡
        /// </param>
        /// <param name="callback" type="Function">
        ///     在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (speed || speed === 0) {
            return this.animate(genFx("hide", 3), speed, easing, callback);

        } else {
            var elem, display,
				i = 0,
				j = this.length;

            for (; i < j; i++) {
                elem = this[i];
                if (elem.style) {
                    display = jQuery.css(elem, "display");

                    if (display !== "none" && !jQuery._data(elem, "olddisplay")) {
                        jQuery._data(elem, "olddisplay", display);
                    }
                }
            }

            // Set the display of the elements in a second loop
            // to avoid the constant reflow
            for (i = 0; i < j; i++) {
                if (this[i].style) {
                    this[i].style.display = "none";
                }
            }

            return this;
        }
    };
    jQuery.prototype.hover = function (fnOver, fnOut) {
        /// <summary>
        ///     1: 将二个事件函数绑定到匹配元素上，分别当鼠标指针进入和离开元素时被执行。
        ///     &#10;    1.1 - hover(handlerIn(eventObject), handlerOut(eventObject))
        ///     &#10;2: 将一个单独事件函数绑定到匹配元素上，分别当鼠标指针进入和离开元素时被执行
        ///     &#10;    2.1 - hover(handlerInOut(eventObject))
        /// </summary>
        /// <param name="fnOver" type="Function">
        ///     当鼠标指针进入元素时触发执行的事件函数
        /// </param>
        /// <param name="fnOut" type="Function">
        ///     当鼠标指针离开元素时触发执行的事件函数
        /// </param>
        /// <returns type="jQuery" />

        return this.mouseenter(fnOver).mouseleave(fnOut || fnOver);
    };
    jQuery.prototype.html = function (value) {
        /// <summary>
        ///     1: 从匹配的第一个元素中获取HTML内容。
        ///     &#10;    1.1 - html()
        ///     &#10;2: 设置每一个匹配元素的html内容
        ///     &#10;    2.1 - html(htmlString)
        ///     &#10;    2.2 - html(function(index, oldhtml))
        /// </summary>
        /// <param name="value" type="String">
        ///     用来设置每个匹配元素的一个HTML 字符串
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (value) {
            var elem = this[0] || {},
				i = 0,
				l = this.length;

            if (value === undefined) {
                return elem.nodeType === 1 ?
					elem.innerHTML.replace(rinlinejQuery, "") :
					null;
            }


            if (typeof value === "string" && !rnoInnerhtml.test(value) &&
				(jQuery.support.leadingWhitespace || !rleadingWhitespace.test(value)) &&
				!wrapMap[(rtagName.exec(value) || ["", ""])[1].toLowerCase()]) {

				    value = value.replace(rxhtmlTag, "<$1></$2>");

				    try {
				        for (; i < l; i++) {
				            // Remove element nodes and prevent memory leaks
				            elem = this[i] || {};
				            if (elem.nodeType === 1) {
				                jQuery.cleanData(elem.getElementsByTagName("*"));
				                elem.innerHTML = value;
				            }
				        }

				        elem = 0;

				        // If using innerHTML throws an exception, use the fallback method
				    } catch (e) { }
				}

            if (elem) {
                this.empty().append(value);
            }
        }, null, value, arguments.length);
    };
    jQuery.prototype.index = function (elem) {
        /// <summary>
        ///     从匹配的元素中搜索给定元素的索引值。索引值从 0 开始计数
        ///     &#10;1 - index()
        ///     &#10;2 - index(selector)
        ///     &#10;3 - index(element)
        /// </summary>
        /// <param name="elem" type="String">
        ///      一个选择器，代表一个 jQuery 集合，将会从这个集合中查找元素
        /// </param>
        /// <returns type="Number" />


        // No argument, return index in parent
        if (!elem) {
            return (this[0] && this[0].parentNode) ? this.prevAll().length : -1;
        }

        // index in selector
        if (typeof elem === "string") {
            return jQuery.inArray(this[0], jQuery(elem));
        }

        // Locate the position of the desired element
        return jQuery.inArray(
			// If it receives a jQuery object, the first element is used
			elem.jquery ? elem[0] : elem, this);
    };
    jQuery.prototype.init = function (selector, context, rootjQuery) {

        var match, elem, ret, doc;

        // Handle $(""), $(null), or $(undefined)
        if (!selector) {
            return this;
        }

        // Handle $(DOMElement)
        if (selector.nodeType) {
            this.context = this[0] = selector;
            this.length = 1;
            return this;
        }

        // The body element only exists once, optimize finding it
        if (selector === "body" && !context && document.body) {
            this.context = document;
            this[0] = document.body;
            this.selector = selector;
            this.length = 1;
            return this;
        }

        // Handle HTML strings
        if (typeof selector === "string") {
            // Are we dealing with HTML string or an ID?
            if (selector.charAt(0) === "<" && selector.charAt(selector.length - 1) === ">" && selector.length >= 3) {
                // Assume that strings that start and end with <> are HTML and skip the regex check
                match = [null, selector, null];

            } else {
                match = quickExpr.exec(selector);
            }

            // Verify a match, and that no context was specified for #id
            if (match && (match[1] || !context)) {

                // HANDLE: $(html) -> $(array)
                if (match[1]) {
                    context = context instanceof jQuery ? context[0] : context;
                    doc = (context ? context.ownerDocument || context : document);

                    // If a single string is passed in and it's a single tag
                    // just do a createElement and skip the rest
                    ret = rsingleTag.exec(selector);

                    if (ret) {
                        if (jQuery.isPlainObject(context)) {
                            selector = [document.createElement(ret[1])];
                            jQuery.fn.attr.call(selector, context, true);

                        } else {
                            selector = [doc.createElement(ret[1])];
                        }

                    } else {
                        ret = jQuery.buildFragment([match[1]], [doc]);
                        selector = (ret.cacheable ? jQuery.clone(ret.fragment) : ret.fragment).childNodes;
                    }

                    return jQuery.merge(this, selector);

                    // HANDLE: $("#id")
                } else {
                    elem = document.getElementById(match[2]);

                    // Check parentNode to catch when Blackberry 4.6 returns
                    // nodes that are no longer in the document #6963
                    if (elem && elem.parentNode) {
                        // Handle the case where IE and Opera return items
                        // by name instead of ID
                        if (elem.id !== match[2]) {
                            return rootjQuery.find(selector);
                        }

                        // Otherwise, we inject the element directly into the jQuery object
                        this.length = 1;
                        this[0] = elem;
                    }

                    this.context = document;
                    this.selector = selector;
                    return this;
                }

                // HANDLE: $(expr, $(...))
            } else if (!context || context.jquery) {
                return (context || rootjQuery).find(selector);

                // HANDLE: $(expr, context)
                // (which is just equivalent to: $(context).find(expr)
            } else {
                return this.constructor(context).find(selector);
            }

            // HANDLE: $(function)
            // Shortcut for document ready
        } else if (jQuery.isFunction(selector)) {
            return rootjQuery.ready(selector);
        }

        if (selector.selector !== undefined) {
            this.selector = selector.selector;
            this.context = selector.context;
        }

        return jQuery.makeArray(selector, this);
    };
    jQuery.prototype.innerHeight = function () {
        /// <summary>
        ///     取得匹配集合中第一个元素经过计算的高度，包括填充，但是不包括边框
        /// </summary>
        /// <returns type="Number" />

        var elem = this[0];
        return elem ?
			elem.style ?
			parseFloat(jQuery.css(elem, type, "padding")) :
			this[type]() :
			null;
    };
    jQuery.prototype.innerWidth = function () {
        /// <summary>
        ///     取得匹配集合中第一个元素经过计算的宽度，包括填充，但是不包括边框
        /// </summary>
        /// <returns type="Number" />

        var elem = this[0];
        return elem ?
			elem.style ?
			parseFloat(jQuery.css(elem, type, "padding")) :
			this[type]() :
			null;
    };
    jQuery.prototype.insertAfter = function (selector) {
        /// <summary>
        ///     将指定的内容，插入到每个匹配元素的后面，作为其兄弟节点
        /// </summary>
        /// <param name="selector" type="jQuery">
        ///     插入的目标，可以是选择器, 元素, HTML 字符串, 或 jQuery 对象。待插入的内容将会被插入到它的后面。
        /// </param>
        /// <returns type="jQuery" />

        var ret = [],
			insert = jQuery(selector),
			parent = this.length === 1 && this[0].parentNode;

        if (parent && parent.nodeType === 11 && parent.childNodes.length === 1 && insert.length === 1) {
            insert[original](this[0]);
            return this;

        } else {
            for (var i = 0, l = insert.length; i < l; i++) {
                var elems = (i > 0 ? this.clone(true) : this).get();
                jQuery(insert[i])[original](elems);
                ret = ret.concat(elems);
            }

            return this.pushStack(ret, name, insert.selector);
        }
    };
    jQuery.prototype.insertBefore = function (selector) {
        /// <summary>
        ///     将指定的内容，插入到每个匹配元素的前面，作为其兄弟节点
        /// </summary>
        /// <param name="selector" type="jQuery">
        ///     插入的目标，可以是选择器, 元素, HTML 字符串, 或 jQuery 对象。待插入的内容将会被插入到它的前面。
        /// </param>
        /// <returns type="jQuery" />

        var ret = [],
			insert = jQuery(selector),
			parent = this.length === 1 && this[0].parentNode;

        if (parent && parent.nodeType === 11 && parent.childNodes.length === 1 && insert.length === 1) {
            insert[original](this[0]);
            return this;

        } else {
            for (var i = 0, l = insert.length; i < l; i++) {
                var elems = (i > 0 ? this.clone(true) : this).get();
                jQuery(insert[i])[original](elems);
                ret = ret.concat(elems);
            }

            return this.pushStack(ret, name, insert.selector);
        }
    };
    jQuery.prototype.is = function (selector) {
        /// <summary>
        ///     判断当前匹配的元素集合中的元素，是否为一个选择器，元素或 jQuery 对象。若匹配的元素集合中至少有一个元素满足给定的参数，则返回 true。
        ///     &#10;1 - is(selector)
        ///     &#10;2 - is(function(index))
        ///     &#10;3 - is(jQuery object)
        ///     &#10;4 - is(element)
        /// </summary>
        /// <param name="selector" type="String">
        ///      用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="Boolean" />

        return !!selector && (
			typeof selector === "string" ?
				// If this is a positional selector, check membership in the returned set
				// so $("p:first").is("p:last") won't return true for a doc with two "p".
				POS.test(selector) ?
					jQuery(selector, this.context).index(this[0]) >= 0 :
					jQuery.filter(selector, this).length > 0 :
				this.filter(selector).length > 0);
    };
    jQuery.prototype.keydown = function (data, fn) {
        /// <summary>
        ///     为 "keydown" 事件绑定一个处理函数，或者触发元素上的 "keydown" 事件
        ///     &#10;1 - keydown(handler(eventObject))
        ///     &#10;2 - keydown(eventData, handler(eventObject))
        ///     &#10;3 - keydown()
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.keypress = function (data, fn) {
        /// <summary>
        ///     为 JavaScript 的 "keypress" 事件绑定一个处理函数，或者触发元素上的该事件
        ///     &#10;1 - keypress(handler(eventObject))
        ///     &#10;2 - keypress(eventData, handler(eventObject))
        ///     &#10;3 - keypress()
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.keyup = function (data, fn) {
        /// <summary>
        ///     为 "keyup" 事件绑定一个处理函数，或者触发元素上的 "keyup" 事件
        ///     &#10;1 - keyup(handler(eventObject))
        ///     &#10;2 - keyup(eventData, handler(eventObject))
        ///     &#10;3 - keyup()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.last = function () {
        /// <summary>
        ///     获取元素集合中最后一个元素
        /// </summary>
        /// <returns type="jQuery" />

        return this.eq(-1);
    };
    jQuery.prototype.length = 0;
    jQuery.prototype.live = function (types, data, fn) {
        /// <summary>
        ///     为所有与选择器匹配的元素添加一个事件处理。匹配的元素包括那些目前已经匹配到的元素，也包括那些今后可能匹配到的元素。
        ///     &#10;1 - live(events, handler(eventObject))
        ///     &#10;2 - live(events, data, handler(eventObject))
        ///     &#10;3 - live(events-map)
        /// </summary>
        /// <param name="types" type="String">
        ///     包含 JavaScript 事件类型的字符串。例如 "click" 或 "keydown"。从 jQuery 1.4 开始，该字符串可以包含多个用空格分隔的事件类型或自定义事件名。
        /// </param>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        jQuery(this.context).on(types, this.selector, data, fn);
        return this;
    };
    jQuery.prototype.load = function (url, params, callback) {
        /// <summary>
        ///     1: 为 JavaScript 的 "load" 事件绑定一个处理函数
        ///     &#10;    1.1 - load(handler(eventObject))
        ///     &#10;    1.2 - load(eventData, handler(eventObject))
        ///     &#10;2: 从服务器加载数据，并将返回的 HTML 结果放到匹配的元素中
        ///     &#10;    2.1 - load(url, data, complete(responseText, textStatus, XMLHttpRequest))
        /// </summary>
        /// <param name="url" type="String">
        ///     将要被请求的 URL 字符串
        /// </param>
        /// <param name="params" type="String">
        ///      可选参数，发送给服务器的字符串或者映射
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，完成请求时要执行的回调函数。 
        /// </param>
        /// <returns type="jQuery" />

        if (typeof url !== "string" && _load) {
            return _load.apply(this, arguments);

            // Don't do a request if no elements are being requested
        } else if (!this.length) {
            return this;
        }

        var off = url.indexOf(" ");
        if (off >= 0) {
            var selector = url.slice(off, url.length);
            url = url.slice(0, off);
        }

        // Default to a GET request
        var type = "GET";

        // If the second parameter was provided
        if (params) {
            // If it's a function
            if (jQuery.isFunction(params)) {
                // We assume that it's the callback
                callback = params;
                params = undefined;

                // Otherwise, build a param string
            } else if (typeof params === "object") {
                params = jQuery.param(params, jQuery.ajaxSettings.traditional);
                type = "POST";
            }
        }

        var self = this;

        // Request the remote document
        jQuery.ajax({
            url: url,
            type: type,
            dataType: "html",
            data: params,
            // Complete callback (responseText is used internally)
            complete: function (jqXHR, status, responseText) {
                // Store the response as specified by the jqXHR object
                responseText = jqXHR.responseText;
                // If successful, inject the HTML into all the matched elements
                if (jqXHR.isResolved()) {
                    // #4825: Get the actual response in case
                    // a dataFilter is present in ajaxSettings
                    jqXHR.done(function (r) {
                        responseText = r;
                    });
                    // See if a selector was specified
                    self.html(selector ?
						// Create a dummy div to hold the results
						jQuery("<div>")
							// inject the contents of the document in, removing the scripts
							// to avoid any 'Permission Denied' errors in IE
							.append(responseText.replace(rscript, ""))

							// Locate the specified elements
							.find(selector) :

						// If not, just inject the full result
						responseText);
                }

                if (callback) {
                    self.each(callback, [responseText, status, jqXHR]);
                }
            }
        });

        return this;
    };
    jQuery.prototype.map = function (callback) {
        /// <summary>
        ///     通过一个函数匹配当前集合中的每个元素,产生一个包含的返回值的jQuery新对象。
        /// </summary>
        /// <param name="callback" type="Function">
        ///     一个函数对象，将调用当前集合中的每个元素
        /// </param>
        /// <returns type="jQuery" />

        return this.pushStack(jQuery.map(this, function (elem, i) {
            return callback.call(elem, i, elem);
        }));
    };
    jQuery.prototype.mousedown = function (data, fn) {
        /// <summary>
        ///     为 "mousedown" 事件绑定一个处理函数，或者触发元素上的 "mousedown" 事件
        ///     &#10;1 - mousedown(handler(eventObject))
        ///     &#10;2 - mousedown(eventData, handler(eventObject))
        ///     &#10;3 - mousedown()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.mouseenter = function (data, fn) {
        /// <summary>
        ///     为 mouse enters（鼠标进入） 事件绑定一个处理函数，或者触发元素上的 mouse enters（鼠标进入） 事件
        ///     &#10;1 - mouseenter(handler(eventObject))
        ///     &#10;2 - mouseenter(eventData, handler(eventObject))
        ///     &#10;3 - mouseenter()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.mouseleave = function (data, fn) {
        /// <summary>
        ///     为 mouse leaves（鼠标离开） 事件绑定一个处理函数，或者触发元素上的 mouse leaves（鼠标离开） 事件
        ///     &#10;1 - mouseleave(handler(eventObject))
        ///     &#10;2 - mouseleave(eventData, handler(eventObject))
        ///     &#10;3 - mouseleave()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.mousemove = function (data, fn) {
        /// <summary>
        ///     为 "mousemove" 事件绑定一个处理函数，或者触发元素上的 "mousemove" 事件
        ///     &#10;1 - mousemove(handler(eventObject))
        ///     &#10;2 - mousemove(eventData, handler(eventObject))
        ///     &#10;3 - mousemove()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.mouseout = function (data, fn) {
        /// <summary>
        ///     为 "mouseout" 事件绑定一个处理函数，或者触发元素上的 "mouseout" 事件
        ///     &#10;1 - mouseout(handler(eventObject))
        ///     &#10;2 - mouseout(eventData, handler(eventObject))
        ///     &#10;3 - mouseout()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.mouseover = function (data, fn) {
        /// <summary>
        ///     为 "mouseover" 事件绑定一个处理函数，或者触发元素上的 "mouseover" 事件
        ///     &#10;1 - mouseover(handler(eventObject))
        ///     &#10;2 - mouseover(eventData, handler(eventObject))
        ///     &#10;3 - mouseover()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.mouseup = function (data, fn) {
        /// <summary>
        ///     为 "mouseup" 事件绑定一个处理函数，或者触发元素上的 "mouseup" 事件
        ///     &#10;1 - mouseup(handler(eventObject))
        ///     &#10;2 - mouseup(eventData, handler(eventObject))
        ///     &#10;3 - mouseup()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.next = function (until, selector) {
        /// <summary>
        ///     取得匹配的元素集合中紧跟着集合中每个元素的兄弟元素。如果提供了选择器，那么只有紧跟着的兄弟元素满足选择器时，才会返回此元素
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.nextAll = function (until, selector) {
        /// <summary>
        ///     取得匹配元素集合中跟在每个元素后面的所有兄弟元素，还可以提供一个可选的选择器
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.nextUntil = function (until, selector) {
        /// <summary>
        ///     查找在当前元素集中，每个元素之后的所有兄弟元素，直到遇到与选择器， DOM 节点或 jQuery 对象匹配的元素为止，但不包括这些元素
        ///     &#10;1 - nextUntil(selector, filter)
        ///     &#10;2 - nextUntil(element, filter)
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，选择器字符串，用于确定匹配到之后的哪个兄弟元素时停止匹配
        /// </param>
        /// <param name="selector" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.not = function (selector) {
        /// <summary>
        ///     选择所有与给定选择器不匹配的元素
        ///     &#10;1 - not(selector)
        ///     &#10;2 - not(elements)
        ///     &#10;3 - not(function(index))
        ///     &#10;4 - not(jQuery object)
        /// </summary>
        /// <param name="selector" type="String">
        ///      用于过滤的选择器
        /// </param>
        /// <returns type="jQuery" />

        return this.pushStack(winnow(this, selector, false), "not", selector);
    };
    jQuery.prototype.off = function (types, selector, fn) {
        /// <summary>
        ///     移除事件处理函数
        ///     &#10;1 - off(events, selector, handler(eventObject))
        ///     &#10;2 - off(events-map, selector)
        /// </summary>
        /// <param name="types" type="String">
        ///     一个或多个由空格分隔的事件类型及可选的名字空间，或者仅有名字空间。例如，"click"， "keydown.myPlugin"， 或 ".myPlugin"
        /// </param>
        /// <param name="selector" type="String">
        ///     可选参数，与之前通过 .on() 进行绑定事件处理时相一致的选择器
        /// </param>
        /// <param name="fn" type="Function">
        ///     可选参数，之前为事件绑定的处理函数，或者是特殊值 false
        /// </param>
        /// <returns type="jQuery" />

        if (types && types.preventDefault && types.handleObj) {
            // ( event )  dispatched jQuery.Event
            var handleObj = types.handleObj;
            jQuery(types.delegateTarget).off(
				handleObj.namespace ? handleObj.origType + "." + handleObj.namespace : handleObj.origType,
				handleObj.selector,
				handleObj.handler
			);
            return this;
        }
        if (typeof types === "object") {
            // ( types-object [, selector] )
            for (var type in types) {
                this.off(type, selector, types[type]);
            }
            return this;
        }
        if (selector === false || typeof selector === "function") {
            // ( types [, fn] )
            fn = selector;
            selector = undefined;
        }
        if (fn === false) {
            fn = returnFalse;
        }
        return this.each(function () {
            jQuery.event.remove(this, types, fn, selector);
        });
    };
    jQuery.prototype.offset = function (options) {
        /// <summary>
        ///     1: 取得第一个匹配元素的相对于文档的坐标
        ///     &#10;    1.1 - offset()
        ///     &#10;2: 为每个匹配的元素设置相对于文档的坐标
        ///     &#10;    2.1 - offset(coordinates)
        ///     &#10;    2.2 - offset(function(index, coords))
        /// </summary>
        /// <param name="options" type="Object">
        ///     一个含有 top 和 left 属性的对象，属性的值是整数。代表将要设置的新位置
        /// </param>
        /// <returns type="jQuery" />

        if (arguments.length) {
            return options === undefined ?
			this :
			this.each(function (i) {
			    jQuery.offset.setOffset(this, options, i);
			});
        }

        var elem = this[0],
		doc = elem && elem.ownerDocument;

        if (!doc) {
            return null;
        }

        if (elem === doc.body) {
            return jQuery.offset.bodyOffset(elem);
        }

        return getOffset(elem, doc, doc.documentElement);
    };
    jQuery.prototype.offsetParent = function () {
        /// <summary>
        ///     取得离指定元素最近的含有定位信息的祖先元素。含有定位信息的元素指的是，CSS 的 position 属性是 relative, absolute, 或 fixed 的元素
        /// </summary>
        /// <returns type="jQuery" />

        return this.map(function () {
            var offsetParent = this.offsetParent || document.body;
            while (offsetParent && (!rroot.test(offsetParent.nodeName) && jQuery.css(offsetParent, "position") === "static")) {
                offsetParent = offsetParent.offsetParent;
            }
            return offsetParent;
        });
    };
    jQuery.prototype.on = function (types, selector, data, fn, /*INTERNAL*/ one) {
        /// <summary>
        ///     为选中元素上的一个或多个事件绑定事件处理函数
        ///     &#10;1 - on(events, selector, data, handler(eventObject))
        ///     &#10;2 - on(events-map, selector, data)
        /// </summary>
        /// <param name="types" type="String">
        ///      一个或多个由空格分隔的事件类型及可选的名字空间，例如："click" 或 "keydown.myPlugin"
        /// </param>
        /// <param name="selector" type="String">
        ///     可选参数，一个选择器字符串，用于过滤出被选中的元素中能触发事件的后代元素。如果选择器是 null 或者忽略了该选择器，那么被选中的元素总是能触发事件
        /// </param>
        /// <param name="data" type="Anything">
        ///     可选参数，当事件触发时，将要传入事件处理函数中的 event.data 的数据
        /// </param>
        /// <param name="fn" type="Function">
        ///      当事件被触发时，执行的函数。若该函数只是要执行 return false 的话，那么该参数位置可以直接简写成 false。 
        /// </param>
        /// <returns type="jQuery" />

        var origFn, type;

        // Types can be a map of types/handlers
        if (typeof types === "object") {
            // ( types-Object, selector, data )
            if (typeof selector !== "string") { // && selector != null
                // ( types-Object, data )
                data = data || selector;
                selector = undefined;
            }
            for (type in types) {
                this.on(type, selector, data, types[type], one);
            }
            return this;
        }

        if (data == null && fn == null) {
            // ( types, fn )
            fn = selector;
            data = selector = undefined;
        } else if (fn == null) {
            if (typeof selector === "string") {
                // ( types, selector, fn )
                fn = data;
                data = undefined;
            } else {
                // ( types, data, fn )
                fn = data;
                data = selector;
                selector = undefined;
            }
        }
        if (fn === false) {
            fn = returnFalse;
        } else if (!fn) {
            return this;
        }

        if (one === 1) {
            origFn = fn;
            fn = function (event) {
                // Can use an empty set, since event contains the info
                jQuery().off(event);
                return origFn.apply(this, arguments);
            };
            // Use same guid so caller can remove using origFn
            fn.guid = origFn.guid || (origFn.guid = jQuery.guid++);
        }
        return this.each(function () {
            jQuery.event.add(this, types, fn, data, selector);
        });
    };
    jQuery.prototype.one = function (types, selector, data, fn) {
        /// <summary>
        ///     附加一个处理事件到元素。处理函数在每个元素上最多执行一次
        ///     &#10;1 - one(events, data, handler(eventObject))
        ///     &#10;2 - one(events, selector, data, handler(eventObject))
        ///     &#10;3 - one(events-map, selector, data)
        /// </summary>
        /// <param name="types" type="String">
        ///     一个或多个由空格分隔的事件类型及可选的名字空间，例如："click" 或 "keydown.myPlugin"
        /// </param>
        /// <param name="selector" type="String">
        ///      可选参数，一个选择器字符串，用于过滤出被选中的元素中能触发事件的后代元素。如果选择器是 null 或者忽略了该选择器，那么被选中的元素总是能触发事件
        /// </param>
        /// <param name="data" type="Anything">
        ///     可选参数，当事件触发时，将要传入事件处理函数中的 event.data 的数据
        /// </param>
        /// <param name="fn" type="Function">
        ///     当事件被触发时，执行的函数。若该函数只是要执行 return false 的话，该参数位置可以直接简写成 false。 
        /// </param>
        /// <returns type="jQuery" />

        return this.on(types, selector, data, fn, 1);
    };
    jQuery.prototype.outerHeight = function (margin) {
        /// <summary>
        ///     为匹配的元素集合中获取第一个元素的当前计算高度值,包括padding，border和选择性的margin
        /// </summary>
        /// <param name="margin" type="Boolean">
        ///     一个表明是否在计算时包含元素的margin的布尔值
        /// </param>
        /// <returns type="Number" />

        var elem = this[0];
        return elem ?
			elem.style ?
			parseFloat(jQuery.css(elem, type, margin ? "margin" : "border")) :
			this[type]() :
			null;
    };
    jQuery.prototype.outerWidth = function (margin) {
        /// <summary>
        ///     为匹配的元素集合中获取第一个元素的当前计算宽度值,包括padding，border
        /// </summary>
        /// <param name="margin" type="Boolean">
        ///     一个表明是否在计算时包含元素的margin的布尔值
        /// </param>
        /// <returns type="Number" />

        var elem = this[0];
        return elem ?
			elem.style ?
			parseFloat(jQuery.css(elem, type, margin ? "margin" : "border")) :
			this[type]() :
			null;
    };
    jQuery.prototype.parent = function (until, selector) {
        /// <summary>
        ///     获得集合中每个匹配元素的父级元素，选择性筛选的选择器
        /// </summary>
        /// <param name="until" type="String">
        ///     选择器字符串，用于确定到哪个前辈元素时停止匹配
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.parents = function (until, selector) {
        /// <summary>
        ///     查找当前匹配元素集合中每个元素的所有祖先元素，可以提供一个可选的选择器
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.parentsUntil = function (until, selector) {
        /// <summary>
        ///     查找当前元素集的每个祖先元素，直到遇到与选择器， DOM 节点或 jQuery 对象匹配的元素为止，但不包括这些元素
        ///     &#10;1 - parentsUntil(selector, filter)
        ///     &#10;2 - parentsUntil(element, filter)
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，选择器表达式字符串，用于确定匹配到哪个祖先元素时停止匹配
        /// </param>
        /// <param name="selector" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.position = function () {
        /// <summary>
        ///     取得第一个匹配元素相对于父元素的偏移坐标
        /// </summary>
        /// <returns type="Object" />

        if (!this[0]) {
            return null;
        }

        var elem = this[0],

		// Get *real* offsetParent
		offsetParent = this.offsetParent(),

		// Get correct offsets
		offset = this.offset(),
		parentOffset = rroot.test(offsetParent[0].nodeName) ? { top: 0, left: 0 } : offsetParent.offset();

        // Subtract element margins
        // note: when an element has margin: auto the offsetLeft and marginLeft
        // are the same in Safari causing offset.left to incorrectly be 0
        offset.top -= parseFloat(jQuery.css(elem, "marginTop")) || 0;
        offset.left -= parseFloat(jQuery.css(elem, "marginLeft")) || 0;

        // Add offsetParent borders
        parentOffset.top += parseFloat(jQuery.css(offsetParent[0], "borderTopWidth")) || 0;
        parentOffset.left += parseFloat(jQuery.css(offsetParent[0], "borderLeftWidth")) || 0;

        // Subtract the two offsets
        return {
            top: offset.top - parentOffset.top,
            left: offset.left - parentOffset.left
        };
    };
    jQuery.prototype.prepend = function () {
        /// <summary>
        ///     在每个匹配元素内的开头插入指定的内容
        ///     &#10;1 - prepend(content, content)
        ///     &#10;2 - prepend(function(index, html))
        /// </summary>
        /// <param name="" type="jQuery">
        ///     将要插入到匹配元素开头的 DOM 元素, HTML 字符串,或 jQuery 对象
        /// </param>
        /// <param name="" type="jQuery">
        ///     可选参数，可选参数，将要插入到匹配元素开头的，一个或多个附加的 DOM 元素, 元素数组, HTML 字符串, 或 jQuery 对象
        /// </param>
        /// <returns type="jQuery" />

        return this.domManip(arguments, true, function (elem) {
            if (this.nodeType === 1) {
                this.insertBefore(elem, this.firstChild);
            }
        });
    };
    jQuery.prototype.prependTo = function (selector) {
        /// <summary>
        ///     将指定的内容，插入到每个匹配元素内的开头
        /// </summary>
        /// <param name="selector" type="jQuery">
        ///     用于插入到匹配元素内的选择器, 元素, HTML 字符串, 或 jQuery 对象
        /// </param>
        /// <returns type="jQuery" />

        var ret = [],
			insert = jQuery(selector),
			parent = this.length === 1 && this[0].parentNode;

        if (parent && parent.nodeType === 11 && parent.childNodes.length === 1 && insert.length === 1) {
            insert[original](this[0]);
            return this;

        } else {
            for (var i = 0, l = insert.length; i < l; i++) {
                var elems = (i > 0 ? this.clone(true) : this).get();
                jQuery(insert[i])[original](elems);
                ret = ret.concat(elems);
            }

            return this.pushStack(ret, name, insert.selector);
        }
    };
    jQuery.prototype.prev = function (until, selector) {
        /// <summary>
        ///     查找匹配元素集合中每个元素前面的直接兄弟元素，可以提供一个可选的选择器
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.prevAll = function (until, selector) {
        /// <summary>
        ///     查找匹配元素集合中每个元素前面的所有兄弟元素，可以提供一个可选的选择器
        /// </summary>
        /// <param name="until" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.prevUntil = function (until, selector) {
        /// <summary>
        ///     获取每个元素但不包括选择器匹配的元素的所有前面的兄弟元素
        ///     &#10;1 - prevUntil(selector, filter)
        ///     &#10;2 - prevUntil(element, filter)
        /// </summary>
        /// <param name="until" type="String">
        ///      可选参数，选择器字符串，用于确定匹配到之前的哪个兄弟元素时停止匹配
        /// </param>
        /// <param name="selector" type="String">
        ///     可选参数，用于匹配元素的选择器表达式字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.promise = function (type, object) {
        /// <summary>
        ///     返回一个 Promise 对象用来观察当某种类型的所有行动绑定到集合，排队与否还是已经完成
        /// </summary>
        /// <param name="type" type="String">
        ///     需要待观察队列类型
        /// </param>
        /// <param name="object" type="Object">
        ///     附有promise 方法的Object
        /// </param>
        /// <returns type="Promise" />

        if (typeof type !== "string") {
            object = type;
            type = undefined;
        }
        type = type || "fx";
        var defer = jQuery.Deferred(),
			elements = this,
			i = elements.length,
			count = 1,
			deferDataKey = type + "defer",
			queueDataKey = type + "queue",
			markDataKey = type + "mark",
			tmp;
        function resolve() {
            if (!(--count)) {
                defer.resolveWith(elements, [elements]);
            }
        }
        while (i--) {
            if ((tmp = jQuery.data(elements[i], deferDataKey, undefined, true) ||
					(jQuery.data(elements[i], queueDataKey, undefined, true) ||
						jQuery.data(elements[i], markDataKey, undefined, true)) &&
					jQuery.data(elements[i], deferDataKey, jQuery.Callbacks("once memory"), true))) {
					    count++;
					    tmp.add(resolve);
					}
        }
        resolve();
        return defer.promise(object);
    };
    jQuery.prototype.prop = function (name, value) {
        /// <summary>
        ///     1: 获取在匹配的元素集中的第一个元素的属性值
        ///     &#10;    1.1 - prop(propertyName)
        ///     &#10;2: 设置为匹配的元素设置一个或更多的属性
        ///     &#10;    2.1 - prop(propertyName, value)
        ///     &#10;    2.2 - prop(map)
        ///     &#10;    2.3 - prop(propertyName, function(index, oldPropertyValue))
        /// </summary>
        /// <param name="name" type="String">
        ///     要设置的属性的名称
        /// </param>
        /// <param name="value" type="Boolean">
        ///     一个值来设置属性值
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, jQuery.prop, name, value, arguments.length > 1);
    };
    jQuery.prototype.pushStack = function (elems, name, selector) {
        /// <summary>
        ///     将一个DOM元素集合加入到jQuery栈
        ///     &#10;1 - pushStack(elements)
        ///     &#10;2 - pushStack(elements, name, arguments)
        /// </summary>
        /// <param name="elems" type="Array">
        ///     将要压入jQuery栈的元素，用于生成一个新的jQuery对象
        /// </param>
        /// <param name="name" type="String">
        ///     将要压入jQuery栈的元素，用于生成一个新的jQuery对象
        /// </param>
        /// <param name="selector" type="Array">
        ///     传递给jQuery方法的参数(用于序列化)
        /// </param>
        /// <returns type="jQuery" />

        // Build a new jQuery matched element set
        var ret = this.constructor();

        if (jQuery.isArray(elems)) {
            push.apply(ret, elems);

        } else {
            jQuery.merge(ret, elems);
        }

        // Add the old object onto the stack (as a reference)
        ret.prevObject = this;

        ret.context = this.context;

        if (name === "find") {
            ret.selector = this.selector + (this.selector ? " " : "") + selector;
        } else if (name) {
            ret.selector = this.selector + "." + name + "(" + selector + ")";
        }

        // Return the newly-formed element set
        return ret;
    };
    jQuery.prototype.queue = function (type, data) {
        /// <summary>
        ///     1: 显示匹配元素上将要执行的函数队列
        ///     &#10;    1.1 - queue(queueName)
        ///     &#10;2: 在匹配元素上操作已经附加函数的列表
        ///     &#10;    2.1 - queue(queueName, newQueue)
        ///     &#10;    2.2 - queue(queueName, callback( next ))
        /// </summary>
        /// <param name="type" type="String">
        ///     一个含有队列名的字符串。默认是"Fx"，标准的动画队列
        /// </param>
        /// <param name="data" type="Array">
        ///     一个替换当前函数列队内容的数组
        /// </param>
        /// <returns type="jQuery" />

        var setter = 2;

        if (typeof type !== "string") {
            data = type;
            type = "fx";
            setter--;
        }

        if (arguments.length < setter) {
            return jQuery.queue(this[0], type);
        }

        return data === undefined ?
			this :
			this.each(function () {
			    var queue = jQuery.queue(this, type, data);

			    if (type === "fx" && queue[0] !== "inprogress") {
			        jQuery.dequeue(this, type);
			    }
			});
    };
    jQuery.prototype.ready = function (fn) {
        /// <summary>
        ///     在 DOM 被完全加载完时，指定将要被执行的函数
        /// </summary>
        /// <param name="fn" type="Function">
        ///     指定在 DOM 被完全加载完时将要被执行的函数
        /// </param>
        /// <returns type="jQuery" />

        // Attach the listeners
        jQuery.bindReady();

        // Add the callback
        readyList.add(fn);

        return this;
    };
    jQuery.prototype.remove = function (selector, keepData) {
        /// <summary>
        ///     从 DOM 中移除匹配的元素，同时移除元素上的事件及 jQuery 数据
        /// </summary>
        /// <param name="selector" type="String">
        ///     可选参数，选择器表达式，用于过滤出将要被移除的元素
        /// </param>
        /// <returns type="jQuery" />

        for (var i = 0, elem; (elem = this[i]) != null; i++) {
            if (!selector || jQuery.filter(selector, [elem]).length) {
                if (!keepData && elem.nodeType === 1) {
                    jQuery.cleanData(elem.getElementsByTagName("*"));
                    jQuery.cleanData([elem]);
                }

                if (elem.parentNode) {
                    elem.parentNode.removeChild(elem);
                }
            }
        }

        return this;
    };
    jQuery.prototype.removeAttr = function (name) {
        /// <summary>
        ///     从每个匹配的元素中移除指定的 attribute 属性
        /// </summary>
        /// <param name="name" type="String">
        ///     将要移除的属性名; 从 jQuery 1.7 开始, 可以指定多个属性名，属性名之间用空格分隔
        /// </param>
        /// <returns type="jQuery" />

        return this.each(function () {
            jQuery.removeAttr(this, name);
        });
    };
    jQuery.prototype.removeClass = function (value) {
        /// <summary>
        ///     移除每个匹配元素上的一个，多个或所有样式
        ///     &#10;1 - removeClass(className)
        ///     &#10;2 - removeClass(function(index, class))
        /// </summary>
        /// <param name="value" type="String">
        ///     可选参数，将要被移除的样式名，样式名之前用空格分隔
        /// </param>
        /// <returns type="jQuery" />

        var classNames, i, l, elem, className, c, cl;

        if (jQuery.isFunction(value)) {
            return this.each(function (j) {
                jQuery(this).removeClass(value.call(this, j, this.className));
            });
        }

        if ((value && typeof value === "string") || value === undefined) {
            classNames = (value || "").split(rspace);

            for (i = 0, l = this.length; i < l; i++) {
                elem = this[i];

                if (elem.nodeType === 1 && elem.className) {
                    if (value) {
                        className = (" " + elem.className + " ").replace(rclass, " ");
                        for (c = 0, cl = classNames.length; c < cl; c++) {
                            className = className.replace(" " + classNames[c] + " ", " ");
                        }
                        elem.className = jQuery.trim(className);

                    } else {
                        elem.className = "";
                    }
                }
            }
        }

        return this;
    };
    jQuery.prototype.removeData = function (key) {
        /// <summary>
        ///     移除先前在元素上存放的数据
        ///     &#10;1 - removeData(name)
        ///     &#10;2 - removeData(list)
        /// </summary>
        /// <param name="key" type="String">
        ///      可选参数，一个字符串键，代表将要被移除的数据
        /// </param>
        /// <returns type="jQuery" />

        return this.each(function () {
            jQuery.removeData(this, key);
        });
    };
    jQuery.prototype.removeProp = function (name) {
        /// <summary>
        ///     移除匹配元素上指定的 property 属性
        /// </summary>
        /// <param name="name" type="String">
        ///     将要被移除的 property 属性名
        /// </param>
        /// <returns type="jQuery" />

        name = jQuery.propFix[name] || name;
        return this.each(function () {
            // try/catch handles cases where IE balks (such as removing a property on window)
            try {
                this[name] = undefined;
                delete this[name];
            } catch (e) { }
        });
    };
    jQuery.prototype.replaceAll = function (selector) {
        /// <summary>
        ///     用指定的内容替换每个匹配的元素
        /// </summary>
        /// <param name="selector" type="String">
        ///     选择器表达式，代表将要被替换的元素
        /// </param>
        /// <returns type="jQuery" />

        var ret = [],
			insert = jQuery(selector),
			parent = this.length === 1 && this[0].parentNode;

        if (parent && parent.nodeType === 11 && parent.childNodes.length === 1 && insert.length === 1) {
            insert[original](this[0]);
            return this;

        } else {
            for (var i = 0, l = insert.length; i < l; i++) {
                var elems = (i > 0 ? this.clone(true) : this).get();
                jQuery(insert[i])[original](elems);
                ret = ret.concat(elems);
            }

            return this.pushStack(ret, name, insert.selector);
        }
    };
    jQuery.prototype.replaceWith = function (value) {
        /// <summary>
        ///     用提供的内容替换所有匹配的元素
        ///     &#10;1 - replaceWith(newContent)
        ///     &#10;2 - replaceWith(function)
        /// </summary>
        /// <param name="value" type="jQuery">
        ///     用来插入的内容，可能是HTML字符串，DOM元素，或者jQuery对象
        /// </param>
        /// <returns type="jQuery" />

        if (this[0] && this[0].parentNode) {
            // Make sure that the elements are removed from the DOM before they are inserted
            // this can help fix replacing a parent with child elements
            if (jQuery.isFunction(value)) {
                return this.each(function (i) {
                    var self = jQuery(this), old = self.html();
                    self.replaceWith(value.call(this, i, old));
                });
            }

            if (typeof value !== "string") {
                value = jQuery(value).detach();
            }

            return this.each(function () {
                var next = this.nextSibling,
					parent = this.parentNode;

                jQuery(this).remove();

                if (next) {
                    jQuery(next).before(value);
                } else {
                    jQuery(parent).append(value);
                }
            });
        } else {
            return this.length ?
				this.pushStack(jQuery(jQuery.isFunction(value) ? value() : value), "replaceWith", value) :
				this;
        }
    };
    jQuery.prototype.resize = function (data, fn) {
        /// <summary>
        ///     为 "resize" 事件绑定一个处理函数，或者触发元素上的 "resize" 事件
        ///     &#10;1 - resize(handler(eventObject))
        ///     &#10;2 - resize(eventData, handler(eventObject))
        ///     &#10;3 - resize()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.scroll = function (data, fn) {
        /// <summary>
        ///     为 "scroll" 事件绑定一个处理函数，或者触发元素上的 "scroll" 事件
        ///     &#10;1 - scroll(handler(eventObject))
        ///     &#10;2 - scroll(eventData, handler(eventObject))
        ///     &#10;3 - scroll()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.scrollLeft = function (val) {
        /// <summary>
        ///     1: 为匹配的元素集合中获取第一个元素的滚动条的水平位置
        ///     &#10;    1.1 - scrollLeft()
        ///     &#10;2: 为匹配的元素集合中每个元素设置滚动条的水平位置
        ///     &#10;    2.1 - scrollLeft(value)
        /// </summary>
        /// <param name="val" type="Number">
        ///     一个用来设置滚动条水平位置的正整数
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (elem, method, val) {
            var win = getWindow(elem);

            if (val === undefined) {
                return win ? (prop in win) ? win[prop] :
					jQuery.support.boxModel && win.document.documentElement[method] ||
						win.document.body[method] :
					elem[method];
            }

            if (win) {
                win.scrollTo(
					!top ? val : jQuery(win).scrollLeft(),
					 top ? val : jQuery(win).scrollTop()
				);

            } else {
                elem[method] = val;
            }
        }, method, val, arguments.length, null);
    };
    jQuery.prototype.scrollTop = function (val) {
        /// <summary>
        ///     1: 为匹配的元素集合中获取第一个元素的滚动条的垂直位置
        ///     &#10;    1.1 - scrollTop()
        ///     &#10;2: 为匹配的元素集合中每个元素设置滚动条的垂直位置
        ///     &#10;    2.1 - scrollTop(value)
        /// </summary>
        /// <param name="val" type="Number">
        ///     一个用来设置滚动条垂直位置的正整数
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (elem, method, val) {
            var win = getWindow(elem);

            if (val === undefined) {
                return win ? (prop in win) ? win[prop] :
					jQuery.support.boxModel && win.document.documentElement[method] ||
						win.document.body[method] :
					elem[method];
            }

            if (win) {
                win.scrollTo(
					!top ? val : jQuery(win).scrollLeft(),
					 top ? val : jQuery(win).scrollTop()
				);

            } else {
                elem[method] = val;
            }
        }, method, val, arguments.length, null);
    };
    jQuery.prototype.select = function (data, fn) {
        /// <summary>
        ///     为 "select" 事件绑定一个处理函数，或者触发元素上的 "select" 事件
        ///     &#10;1 - select(handler(eventObject))
        ///     &#10;2 - select(eventData, handler(eventObject))
        ///     &#10;3 - select()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.serialize = function () {
        /// <summary>
        ///     将用作提交的表单元素的值编译成字符串
        /// </summary>
        /// <returns type="String" />

        return jQuery.param(this.serializeArray());
    };
    jQuery.prototype.serializeArray = function () {
        /// <summary>
        ///     将用作提交的表单元素的值编译成拥有name和value对象组成的数组
        /// </summary>
        /// <returns type="Array" />

        return this.map(function () {
            return this.elements ? jQuery.makeArray(this.elements) : this;
        })
		.filter(function () {
		    return this.name && !this.disabled &&
				(this.checked || rselectTextarea.test(this.nodeName) ||
					rinput.test(this.type));
		})
		.map(function (i, elem) {
		    var val = jQuery(this).val();

		    return val == null ?
				null :
				jQuery.isArray(val) ?
					jQuery.map(val, function (val, i) {
					    return { name: elem.name, value: val.replace(rCRLF, "\r\n") };
					}) :
					{ name: elem.name, value: val.replace(rCRLF, "\r\n") };
		}).get();
    };
    jQuery.prototype.show = function (speed, easing, callback) {
        /// <summary>
        ///     显示匹配的元素.
        ///     &#10;1 - show()
        ///     &#10;2 - show(duration, callback)
        ///     &#10;3 - show(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     一个字符串或者数字决定动画将运行多久
        /// </param>
        /// <param name="easing" type="String">
        ///     一个用来表示使用哪个缓冲函数来过渡的字符串
        /// </param>
        /// <param name="callback" type="Function">
        ///     在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        var elem, display;

        if (speed || speed === 0) {
            return this.animate(genFx("show", 3), speed, easing, callback);

        } else {
            for (var i = 0, j = this.length; i < j; i++) {
                elem = this[i];

                if (elem.style) {
                    display = elem.style.display;

                    // Reset the inline display of this element to learn if it is
                    // being hidden by cascaded rules or not
                    if (!jQuery._data(elem, "olddisplay") && display === "none") {
                        display = elem.style.display = "";
                    }

                    // Set elements which have been overridden with display: none
                    // in a stylesheet to whatever the default browser style is
                    // for such an element
                    if ((display === "" && jQuery.css(elem, "display") === "none") ||
						!jQuery.contains(elem.ownerDocument.documentElement, elem)) {
						    jQuery._data(elem, "olddisplay", defaultDisplay(elem.nodeName));
						}
                }
            }

            // Set the display of most of the elements in a second loop
            // to avoid the constant reflow
            for (i = 0; i < j; i++) {
                elem = this[i];

                if (elem.style) {
                    display = elem.style.display;

                    if (display === "" || display === "none") {
                        elem.style.display = jQuery._data(elem, "olddisplay") || "";
                    }
                }
            }

            return this;
        }
    };
    jQuery.prototype.siblings = function (until, selector) {
        /// <summary>
        ///     获得匹配元素集合中每个元素的兄弟元素，选择性筛选的选择器
        /// </summary>
        /// <param name="until" type="String">
        ///     一个用于匹配元素的选择器字符串
        /// </param>
        /// <returns type="jQuery" />

        var ret = jQuery.map(this, fn, until);

        if (!runtil.test(name)) {
            selector = until;
        }

        if (selector && typeof selector === "string") {
            ret = jQuery.filter(selector, ret);
        }

        ret = this.length > 1 && !guaranteedUnique[name] ? jQuery.unique(ret) : ret;

        if ((this.length > 1 || rmultiselector.test(selector)) && rparentsprev.test(name)) {
            ret = ret.reverse();
        }

        return this.pushStack(ret, name, slice.call(arguments).join(","));
    };
    jQuery.prototype.size = function () {
        /// <summary>
        ///     返回的jQuery对象匹配的DOM元素的数量
        /// </summary>
        /// <returns type="Number" />

        return this.length;
    };
    jQuery.prototype.slice = function () {
        /// <summary>
        ///     减少匹配元素集合由索引范围到指定的一个子集
        /// </summary>
        /// <param name="" type="Number">
        ///     一个整数，指示0的位置上的元素开始被选中。如果为负，则表示从集合的末尾的偏移量
        /// </param>
        /// <param name="" type="Number">
        ///     一个整数，指示0的位置上被选中的元素停止。如果为负，则表示从集的末尾的偏移量。如果省略，范围，持续到集合的末尾
        /// </param>
        /// <returns type="jQuery" />

        return this.pushStack(slice.apply(this, arguments),
			"slice", slice.call(arguments).join(","));
    };
    jQuery.prototype.slideDown = function (speed, easing, callback) {
        /// <summary>
        ///     通过滑动的形式显示元素
        ///     &#10;1 - slideDown(duration, callback)
        ///     &#10;2 - slideDown(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     可选参数，字符串("slow"或 "fast")或表示动画时长的毫秒数值
        /// </param>
        /// <param name="easing" type="String">
        ///     可选参数，要使用的缓冲效果的名称
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.animate(props, speed, easing, callback);
    };
    jQuery.prototype.slideToggle = function (speed, easing, callback) {
        /// <summary>
        ///     通过滑动的形式显示或隐藏匹配的元素
        ///     &#10;1 - slideToggle(duration, callback)
        ///     &#10;2 - slideToggle(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     可选参数，字符串("slow"或 "fast")或表示动画时长的毫秒数值
        /// </param>
        /// <param name="easing" type="String">
        ///     可选参数，要使用的缓冲效果的名称
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.animate(props, speed, easing, callback);
    };
    jQuery.prototype.slideUp = function (speed, easing, callback) {
        /// <summary>
        ///     用滑动的形式隐藏匹配的元素
        ///     &#10;1 - slideUp(duration, callback)
        ///     &#10;2 - slideUp(duration, easing, callback)
        /// </summary>
        /// <param name="speed" type="Number">
        ///     可选参数，字符串("slow"或 "fast")或表示动画时长的毫秒数值
        /// </param>
        /// <param name="easing" type="String">
        ///     可选参数，要使用的缓冲效果的名称
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，在动画完成时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.animate(props, speed, easing, callback);
    };
    jQuery.prototype.stop = function (type, clearQueue, gotoEnd) {
        /// <summary>
        ///     停止匹配元素当前正在运行的动画
        ///     &#10;1 - stop(clearQueue, jumpToEnd)
        ///     &#10;2 - stop(queue, clearQueue, jumpToEnd)
        /// </summary>
        /// <param name="type" type="String">
        ///     可选参数，队列中动画的名字，只有该动画会被停止
        /// </param>
        /// <param name="clearQueue" type="Boolean">
        ///     可选参数，布尔值，表示是否应该立即完成当前动画。默认值 false
        /// </param>
        /// <param name="gotoEnd" type="Boolean">
        ///     A Boolean indicating whether to complete the current animation immediately. Defaults to false.
        /// </param>
        /// <returns type="jQuery" />

        if (typeof type !== "string") {
            gotoEnd = clearQueue;
            clearQueue = type;
            type = undefined;
        }
        if (clearQueue && type !== false) {
            this.queue(type || "fx", []);
        }

        return this.each(function () {
            var index,
				hadTimers = false,
				timers = jQuery.timers,
				data = jQuery._data(this);

            // clear marker counters if we know they won't be
            if (!gotoEnd) {
                jQuery._unmark(true, this);
            }

            function stopQueue(elem, data, index) {
                var hooks = data[index];
                jQuery.removeData(elem, index, true);
                hooks.stop(gotoEnd);
            }

            if (type == null) {
                for (index in data) {
                    if (data[index] && data[index].stop && index.indexOf(".run") === index.length - 4) {
                        stopQueue(this, data, index);
                    }
                }
            } else if (data[index = type + ".run"] && data[index].stop) {
                stopQueue(this, data, index);
            }

            for (index = timers.length; index--;) {
                if (timers[index].elem === this && (type == null || timers[index].queue === type)) {
                    if (gotoEnd) {

                        // force the next step to be the last
                        timers[index](true);
                    } else {
                        timers[index].saveState();
                    }
                    hadTimers = true;
                    timers.splice(index, 1);
                }
            }

            // start the next in the queue if the last step wasn't forced
            // timers currently will call their complete callbacks, which will dequeue
            // but only if they were gotoEnd
            if (!(gotoEnd && hadTimers)) {
                jQuery.dequeue(this, type);
            }
        });
    };
    jQuery.prototype.submit = function (data, fn) {
        /// <summary>
        ///     为 "submit" 事件绑定一个处理函数，或者触发元素上的 "submit" 事件
        ///     &#10;1 - submit(handler(eventObject))
        ///     &#10;2 - submit(eventData, handler(eventObject))
        ///     &#10;3 - submit()
        /// </summary>
        /// <param name="data" type="Object">
        ///     将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每次事件触发时会执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.text = function (value) {
        /// <summary>
        ///     1: 选择所有的文本输入框，即 type 为 text 的元素
        ///     &#10;    1.1 - text()
        ///     &#10;2: 设置匹配元素集合中每个元素的文本内容为指定的文本内容
        ///     &#10;    2.1 - text(textString)
        ///     &#10;    2.2 - text(function(index, text))
        /// </summary>
        /// <param name="value" type="String">
        ///     用于设置匹配元素内容的文本
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (value) {
            return value === undefined ?
				jQuery.text(this) :
				this.empty().append((this[0] && this[0].ownerDocument || document).createTextNode(value));
        }, null, value, arguments.length);
    };
    jQuery.prototype.toArray = function () {
        /// <summary>
        ///     返回一个包含jQuery对象集合中的所有DOM元素的数组
        /// </summary>
        /// <returns type="Array" />

        return slice.call(this, 0);
    };
    jQuery.prototype.toggle = function (fn, fn2, callback) {
        /// <summary>
        ///     1: 为匹配的元素绑定两个或多个事件，用于点击事件时切换使用
        ///     &#10;    1.1 - toggle(handler(eventObject), handler(eventObject), handler(eventObject))
        ///     &#10;2: 显示或隐藏匹配的元素
        ///     &#10;    2.1 - toggle(duration, callback)
        ///     &#10;    2.2 - toggle(duration, easing, callback)
        ///     &#10;    2.3 - toggle(showOrHide)
        /// </summary>
        /// <param name="fn" type="Function">
        ///     偶数次点击时，执行的函数
        /// </param>
        /// <param name="fn2" type="Function">
        ///     奇数次点击时，执行的函数
        /// </param>
        /// <param name="callback" type="Function">
        ///     可选参数，可选函数，参与循环点击的，用于上述循环点击外执行的函数
        /// </param>
        /// <returns type="jQuery" />

        var bool = typeof fn === "boolean";

        if (jQuery.isFunction(fn) && jQuery.isFunction(fn2)) {
            this._toggle.apply(this, arguments);

        } else if (fn == null || bool) {
            this.each(function () {
                var state = bool ? fn : jQuery(this).is(":hidden");
                jQuery(this)[state ? "show" : "hide"]();
            });

        } else {
            this.animate(genFx("toggle", 3), fn, fn2, callback);
        }

        return this;
    };
    jQuery.prototype.toggleClass = function (value, stateVal) {
        /// <summary>
        ///     根据样式是否存在或根据 switch 参数，为每个匹配的元素添加或移除一个或多个样式
        ///     &#10;1 - toggleClass(className)
        ///     &#10;2 - toggleClass(className, switch)
        ///     &#10;3 - toggleClass(switch)
        ///     &#10;4 - toggleClass(function(index, class, switch), switch)
        /// </summary>
        /// <param name="value" type="String">
        ///      为每个匹配的元素设置切换时用的一个或多个样式名，样式名之间用空格分隔
        /// </param>
        /// <param name="stateVal" type="Boolean">
        ///      布尔值（不只是 truthy/falsy），用于判断样式是否应该被添加或移除
        /// </param>
        /// <returns type="jQuery" />

        var type = typeof value,
			isBool = typeof stateVal === "boolean";

        if (jQuery.isFunction(value)) {
            return this.each(function (i) {
                jQuery(this).toggleClass(value.call(this, i, this.className, stateVal), stateVal);
            });
        }

        return this.each(function () {
            if (type === "string") {
                // toggle individual class names
                var className,
					i = 0,
					self = jQuery(this),
					state = stateVal,
					classNames = value.split(rspace);

                while ((className = classNames[i++])) {
                    // check each className given, space seperated list
                    state = isBool ? state : !self.hasClass(className);
                    self[state ? "addClass" : "removeClass"](className);
                }

            } else if (type === "undefined" || type === "boolean") {
                if (this.className) {
                    // store className if set
                    jQuery._data(this, "__className__", this.className);
                }

                // toggle whole className
                this.className = this.className || value === false ? "" : jQuery._data(this, "__className__") || "";
            }
        });
    };
    jQuery.prototype.trigger = function (type, data) {
        /// <summary>
        ///     在匹配的元素上，执行指定事件类型的所有的处理函数
        ///     &#10;1 - trigger(eventType, extraParameters)
        ///     &#10;2 - trigger(event)
        /// </summary>
        /// <param name="type" type="String">
        ///     包含 JavaScript 事件类型的字符串。例如 click 或 submit
        /// </param>
        /// <param name="data" type="Object">
        ///     可选参数，传到事件处理函数中的额外参数
        /// </param>
        /// <returns type="jQuery" />

        return this.each(function () {
            jQuery.event.trigger(type, data, this);
        });
    };
    jQuery.prototype.triggerHandler = function (type, data) {
        /// <summary>
        ///     执行绑定在元素上指定事件的所有处理函数
        /// </summary>
        /// <param name="type" type="String">
        ///     包含 JavaScript 事件类型的字符串。例如 click 或 submit
        /// </param>
        /// <param name="data" type="Array">
        ///     可选参数，传入到事件处理中的额外参数数组
        /// </param>
        /// <returns type="Object" />

        if (this[0]) {
            return jQuery.event.trigger(type, data, this[0], true);
        }
    };
    jQuery.prototype.unbind = function (types, fn) {
        /// <summary>
        ///     从元素上移除先前绑定的事件
        ///     &#10;1 - unbind(eventType, handler(eventObject))
        ///     &#10;2 - unbind(eventType, false)
        ///     &#10;3 - unbind(event)
        /// </summary>
        /// <param name="types" type="String">
        ///     可选参数，包含 JavaScript 事件类型的字符串。例如 click 或 submit
        /// </param>
        /// <param name="fn" type="Function">
        ///     可选参数，不再需要执行的函数
        /// </param>
        /// <returns type="jQuery" />

        return this.off(types, null, fn);
    };
    jQuery.prototype.undelegate = function (selector, types, fn) {
        /// <summary>
        ///     移除所有匹配元素上的事件，基于一个指定的根元素的子集
        ///     &#10;1 - undelegate()
        ///     &#10;2 - undelegate(selector, eventType)
        ///     &#10;3 - undelegate(selector, eventType, handler(eventObject))
        ///     &#10;4 - undelegate(selector, events)
        ///     &#10;5 - undelegate(namespace)
        /// </summary>
        /// <param name="selector" type="String">
        ///     用于过滤事件结果的选择器
        /// </param>
        /// <param name="types" type="String">
        ///     包含 JavaScript 事件类型的字符串。例如 "click" 或 "keydown"
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        // ( namespace ) or ( selector, types [, fn] )
        return arguments.length == 1 ? this.off(selector, "**") : this.off(types, selector, fn);
    };
    jQuery.prototype.unload = function (data, fn) {
        /// <summary>
        ///     为 JavaScript 的 "unload" 事件绑定一个处理函数
        ///     &#10;1 - unload(handler(eventObject))
        ///     &#10;2 - unload(eventData, handler(eventObject))
        /// </summary>
        /// <param name="data" type="Object">
        ///     可选参数，将要传递给事件处理函数的数据映射
        /// </param>
        /// <param name="fn" type="Function">
        ///     每当事件触发时执行的函数
        /// </param>
        /// <returns type="jQuery" />

        if (fn == null) {
            fn = data;
            data = null;
        }

        return arguments.length > 0 ?
			this.on(name, null, data, fn) :
			this.trigger(name);
    };
    jQuery.prototype.unwrap = function () {
        /// <summary>
        ///     从 DOM 中，移除匹配元素的父元素，仅留下匹配的元素
        /// </summary>
        /// <returns type="jQuery" />

        return this.parent().each(function () {
            if (!jQuery.nodeName(this, "body")) {
                jQuery(this).replaceWith(this.childNodes);
            }
        }).end();
    };
    jQuery.prototype.val = function (value) {
        /// <summary>
        ///     1: 取得匹配元素集合中，第一个元素的值
        ///     &#10;    1.1 - val()
        ///     &#10;2: 为每个匹配的元素设置值
        ///     &#10;    2.1 - val(value)
        ///     &#10;    2.2 - val(function(index, value))
        /// </summary>
        /// <param name="value" type="String">
        ///      将要被设置的值。或者是将要被选中的项目。该值可以是字符串，或字符串数
        /// </param>
        /// <returns type="jQuery" />

        var hooks, ret, isFunction,
			elem = this[0];

        if (!arguments.length) {
            if (elem) {
                hooks = jQuery.valHooks[elem.type] || jQuery.valHooks[elem.nodeName.toLowerCase()];

                if (hooks && "get" in hooks && (ret = hooks.get(elem, "value")) !== undefined) {
                    return ret;
                }

                ret = elem.value;

                return typeof ret === "string" ?
					// handle most common string cases
					ret.replace(rreturn, "") :
					// handle cases where value is null/undef or number
					ret == null ? "" : ret;
            }

            return;
        }

        isFunction = jQuery.isFunction(value);

        return this.each(function (i) {
            var self = jQuery(this), val;

            if (this.nodeType !== 1) {
                return;
            }

            if (isFunction) {
                val = value.call(this, i, self.val());
            } else {
                val = value;
            }

            // Treat null/undefined as ""; convert numbers to string
            if (val == null) {
                val = "";
            } else if (typeof val === "number") {
                val += "";
            } else if (jQuery.isArray(val)) {
                val = jQuery.map(val, function (value) {
                    return value == null ? "" : value + "";
                });
            }

            hooks = jQuery.valHooks[this.type] || jQuery.valHooks[this.nodeName.toLowerCase()];

            // If set returns undefined, fall back to normal setting
            if (!hooks || !("set" in hooks) || hooks.set(this, val, "value") === undefined) {
                this.value = val;
            }
        });
    };
    jQuery.prototype.width = function (value) {
        /// <summary>
        ///     1: 取得匹配集合中第一个元素经过计算后的宽度
        ///     &#10;    1.1 - width()
        ///     &#10;2: 为每个匹配的元素设置 CSS 宽度
        ///     &#10;    2.1 - width(value)
        ///     &#10;    2.2 - width(function(index, width))
        /// </summary>
        /// <param name="value" type="Number">
        ///     设置宽度用的像素值，可以是不带单位的整数值，也可以是整数带单位的字符串
        /// </param>
        /// <returns type="jQuery" />

        return jQuery.access(this, function (elem, type, value) {
            var doc, docElemProp, orig, ret;

            if (jQuery.isWindow(elem)) {
                // 3rd condition allows Nokia support, as it supports the docElem prop but not CSS1Compat
                doc = elem.document;
                docElemProp = doc.documentElement[clientProp];
                return jQuery.support.boxModel && docElemProp ||
					doc.body && doc.body[clientProp] || docElemProp;
            }

            // Get document width or height
            if (elem.nodeType === 9) {
                // Either scroll[Width/Height] or offset[Width/Height], whichever is greater
                doc = elem.documentElement;

                // when a window > document, IE6 reports a offset[Width/Height] > client[Width/Height]
                // so we can't use max, as it'll choose the incorrect offset[Width/Height]
                // instead we use the correct client[Width/Height]
                // support:IE6
                if (doc[clientProp] >= doc[scrollProp]) {
                    return doc[clientProp];
                }

                return Math.max(
					elem.body[scrollProp], doc[scrollProp],
					elem.body[offsetProp], doc[offsetProp]
				);
            }

            // Get width or height on the element
            if (value === undefined) {
                orig = jQuery.css(elem, type);
                ret = parseFloat(orig);
                return jQuery.isNumeric(ret) ? ret : orig;
            }

            // Set the width or height on the element
            jQuery(elem).css(type, value);
        }, type, value, arguments.length, null);
    };
    jQuery.prototype.wrap = function (html) {
        /// <summary>
        ///     在每个匹配的元素外包裹一个 HTML 结构
        ///     &#10;1 - wrap(wrappingElement)
        ///     &#10;2 - wrap(function(index))
        /// </summary>
        /// <param name="html" type="jQuery">
        ///     用于包裹匹配元素的 HTML 代码片断，选择器表达式，jQuery 对象，或 DOM 元素。
        /// </param>
        /// <returns type="jQuery" />

        var isFunction = jQuery.isFunction(html);

        return this.each(function (i) {
            jQuery(this).wrapAll(isFunction ? html.call(this, i) : html);
        });
    };
    jQuery.prototype.wrapAll = function (html) {
        /// <summary>
        ///     将所有匹配的元素作为一个整体，并在其外部包裹一个 HTML 结构
        /// </summary>
        /// <param name="html" type="jQuery">
        ///      用于包裹匹配元素的 HTML 代码片断，选择器表达式，jQuery 对象，或 DOM 元素。
        /// </param>
        /// <returns type="jQuery" />

        if (jQuery.isFunction(html)) {
            return this.each(function (i) {
                jQuery(this).wrapAll(html.call(this, i));
            });
        }

        if (this[0]) {
            // The elements to wrap the target around
            var wrap = jQuery(html, this[0].ownerDocument).eq(0).clone(true);

            if (this[0].parentNode) {
                wrap.insertBefore(this[0]);
            }

            wrap.map(function () {
                var elem = this;

                while (elem.firstChild && elem.firstChild.nodeType === 1) {
                    elem = elem.firstChild;
                }

                return elem;
            }).append(this);
        }

        return this;
    };
    jQuery.prototype.wrapInner = function (html) {
        /// <summary>
        ///     为每个匹配元素的内容包裹一个 HTML 结构
        ///     &#10;1 - wrapInner(wrappingElement)
        ///     &#10;2 - wrapInner(function(index))
        /// </summary>
        /// <param name="html" type="String">
        ///      用于包裹匹配元素内容的 HTML 代码片断，选择器表达式，jQuery 对象，或 DOM 元素。 
        /// </param>
        /// <returns type="jQuery" />

        if (jQuery.isFunction(html)) {
            return this.each(function (i) {
                jQuery(this).wrapInner(html.call(this, i));
            });
        }

        return this.each(function () {
            var self = jQuery(this),
				contents = self.contents();

            if (contents.length) {
                contents.wrapAll(html);

            } else {
                self.append(html);
            }
        });
    };
    jQuery.fn = jQuery.prototype;
    jQuery.fn.init.prototype = jQuery.fn;
    window.jQuery = window.$ = jQuery;
})(window);