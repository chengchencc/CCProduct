
/*****************************************************************************************
*描述：GridView功能扩展的JQuery插件
*功能：实现对微软GridView功能的扩展
******************************************************************************************/

/*初始化GRIDVIEW*/
(function ($) {
    var manager = {}; //用来存储GridView对象的管理池
    $(function () {
        $.fn.extend({
            //gridView控件启用方法
            GridViewInit: function () {
                //将GridView对象实例存储到管理池中，如当前控件id为gvTest，则实例存储在manager.gvTest里
                if ($(this).length == 0) return
                manager[$(this)[0].id] = new GridView($(this)[0], arguments[0]);
                init(manager[$(this)[0].id]);
            },
            //获取选中行index
            selectedIndex: function () {
                return manager[$(this)[0].id].selectedRowIndex;
            },
            //根据id获取值
            getValue: function () {
                if (arguments.length == 1)
                    return manager[$(this)[0].id].getSelectedRowValue(arguments[0]);
                else
                    return manager[$(this)[0].id].getSelectedRowValue();
            },
            //删除行
            deleteRow: function () {
                if (arguments.length == 2)//根据传入的参数列表的长度，判断实现的是什么方法（多态）
                    return manager[$(this)[0].id].rowEventHandler("delete", arguments[0], arguments[1]);
                else
                    return manager[$(this)[0].id].rowEventHandler("delete", arguments[0]);
            },
            //修改行数据
            updateRow: function () {
                if (arguments.length == 2)
                    return manager[$(this)[0].id].rowEventHandler("update", arguments[0], arguments[1]);
                else
                    return manager[$(this)[0].id].rowEventHandler("update", arguments[0]);
            },
            //隐藏行（暂未实现）
            hiddenRow: function () {
                return manager[$(this)[0].id].rowEventHandler("hidden", arguments[0]);
            },
            //锁定gridview脚本的方法
            isBlock: function () {
                if (arguments.length == 2)
                    return manager[$(this)[0].id].isGvBlock(arguments[0], arguments[1]);
                else
                    return manager[$(this)[0].id].isGvBlock(arguments[0]);
            },
            clickRow: function () {
                manager[$(this)[0].id].onGvRowClick(arguments[0]);
            }
        });
    });
    /**
    *功能：GridView对象
    *传入参数：obj 当前页面GridView解析出来的table对象
    */
    function GridView(obj, options) {

        /*默认设置*/
        var defaults = {
            txtIndex: null,     //页面记录选中行控件的ID
            txtExcel: null,     //页面记录导出excel字符串的控件ID
            gvHeight: null,     //gridview的高度
            header: null,      //记录表头信息
            fixedCols: null,     //固定列
            isSorted: true,
            selectedRowCss: "GridViewSelectRow",    //选中行的样式名称
            mouseOverRowCss: "GridViewMouseOverRow",   //鼠标移动到某一行的样式名称
            onRowClicking: null,    //单击前时间
            onRowClick: null,     //单击事件
            onRowDblClick: null     //双击事件
        };
        this.options = $.extend(true, defaults, options);   //GridView的设置
        /*属性定义*/
        this.GvTable = obj;    //记录GridView的Table
        this.$GvHeader = null;     //记录GridView表头的$对象
        this.$GvBody = null;      //记录GridView的表体$对象

        this.pubRowColor = "#FFFFFF";    //记录一行的原本颜色
        this.selectRow = null;    //记录当前选中行
        this.selectedRowIndex = 0;
        this.curRow = null;   //记录鼠标所在行
        this.prevRow = null;    //记录上一次选中行

        this.sortStatus = new Array();    //定义一个记录每列排序的flag的数组，值为true、false
        this.arrTb = new Array();    //记录table数据
        this.arrTbHead = new Array();    //存储表头
        this.arrTbBody = new Array();    //存储表体
        this.headerRowCount = 1;    //定义表头行数
        this.isMergeCellsGv = false;    //记录是否为复杂表体
        this.unmergeColsCount = 0;  //记录没有进行单元格合并的列数,主要在复杂表体中使用

        this.isBlock = false;
        this.message = null;

        if ($(this.GvTable).children("tbody").children("tr").length <= 1 || !this.GvTable.parentElement.tagName.toLowerCase == "div")
            return this.isBlock = true;
        /*初始化*/
        this.setDivHeight()
        resizeGv(this)
        getHeaderRow(this); //获取当前table表头行数
        setHeaderCss(this); //多表头重置样式
        getGvData(this); //获取table中的数据，存储于arrTb中
        gvConvertToString(this); //
        isMergeCells(this); //判断表体是否有合并单元格,并返回未合并单元格的列数
        eventBinding(this); //事件绑定
        resizeColWidth(this); //动态调整表格宽度事件绑定
        //        fixedItem(this);  //  固定元素
        //        this.rewriteHeader(this.options.header)

    }
    /*方法定义*/
    GridView.prototype = {

        constructor: GridView,
        isResize: false,
        /**
        *描述：单击行事件，将选中行变色，向“txtIndex”写入当前行索引
        *传入参数：Row 当前选中行
        */
        onGvRowClick: function (Row) {
            if (this.prevRow == Row) return; //重复点击的时候跳出
            var isReady = true;
            var rowData = getRowData(this, Row.rowIndex); //当前行显示数据的一个数组
            if (typeof (this.options.onRowClicking) == "function") {
                isReady = this.options.onRowClicking.call(this.selectRow, rowData); //根据onRowClicking（）的返回值确定是否继续执行单击事件
            }
            if (isReady == false) return;
            this.selectRow = Row;
            this.curRow = Row;
            this.selectedRowIndex = Row.rowIndex;     //获取选中行
            if (this.prevRow != "" && this.prevRow != undefined) {
                $(this.prevRow).removeClass(this.options.selectedRowCss); //移除上一次选中行的样式
            }
            $(Row).addClass(this.options.selectedRowCss); //添加选中行的样式
            $(Row).removeClass(this.options.mouseOverRowCss); //移除鼠标移动到一行的样式
            this.prevRow = Row;
            try {
                $("#" + this.options.txtIndex).val(this.selectedRowIndex);
                if (typeof (this.options.onRowClick) == "function" && isReady) {
                    //执行初始化传入的onRowClick（）事件，传入参数rowData，并将其作用域绑定到当前行
                    this.options.onRowClick.call(this.selectRow, rowData);
                }
            }
            catch (e) {
            }
            //处理合并行，去掉不规整的部分的变色
            removeColor(this);
        },
        /**
        *描述：双击事件
        */
        onGvDbRowClick: function (Row) {
            if (typeof (this.options.onRowDblClick) == "function") {
                var rowData = getRowData(this, Row.rowIndex)
                this.options.onRowDblClick.call(this.selectRow, rowData);
            }
        },
        /**
        *描述：点击列进行排序
        *传入参数：th 当前选中列
        */
        onClickCellsSort: function (th) {
            if (this.isResize) return;  //正在调整列宽时不触发排序
            if (this.isMergeCellsGv) return; //如果是存在合并行的表体，不进行排序
            if (!this.options.isSorted) return;
            var picAscHtml = "<img alt=\"升序\" style=\"height:10px;width:10px\" src=\"../Public_Web/Images/up.png\" />";
            var picDescHtml = "<img alt=\"降序\" style=\"height:10px;width:10px\" src=\"../Public_Web/Images/down.png\" />";
            var selectedCells = $(th).prevAll().length;; //获得选中列索引
            var tb = this.GvTable;
            var arrTbBody = this.arrTbBody;
            var arrTbHead = objectClone(this.arrTbHead);
            //根据选中列的索引对表体排序
            arrTbBody.sort(function (x, y) {
                if (x[selectedCells].showValue > y[selectedCells].showValue) {
                    return 1;
                }
                else {
                    return -1;
                };
            });
            //重置表头,去掉上次排序插入的图片
            for (var i = 0; i < this.headerRowCount; i++) {
                for (var j = 0; j < tb.rows[i].cells.length; j++) {
                    tb.rows[i].cells[j].innerHTML = arrTbHead[i][j].innerHTML;
                }
            }
            //根据点击次数判断是否逆序
            if (this.sortStatus[selectedCells]) {
                arrTbBody.reverse();
                this.sortStatus[selectedCells] = false;
                th.innerHTML += picAscHtml; //为选中列表头加上排序图片
            }
            else {
                this.sortStatus[selectedCells] = true;
                th.innerHTML += picDescHtml;
            }
            //将排好序的表体输出到页面
            for (var i = this.headerRowCount; i < tb.rows.length; i++) {
                for (var j = 0; j < tb.rows[i].cells.length; j++) {
                    tb.rows[i].cells[j].innerHTML = arrTbBody[i - this.headerRowCount][j].innerHTML;
                }
            }
        },
        /**
        *描述:根据控件id取值
        *传入参数：itemID 控件ID
        *返回参数：value 控件的值
        */
        getSelectedRowValue: function (value) {
            if (this.curRow == null || this.curRow == undefined)
                return undefined;
            var flag = typeof (value);
            switch (flag) {
                case "string":
                    return getselectedRowValueById(value, this.curRow);
                    break;
                case "number":
                    return getRowData(this, this.curRow.rowIndex)[value];
                    break;
                default:
                    return getRowData(this, this.curRow.rowIndex)
                    break;
            }
        },
        /**
        *描述：是否锁定插件的一些方法
        *参数：isBlock 是否锁定（值为true或false）
        *      message 锁定后提示的信息
        */
        isGvBlock: function (isBlock, message) {
            if (arguments.length == 2) {
                if (isBlock) {
                    this.isBlock = true;
                    this.message = message;;
                }
                else {
                    this.isBlock = false;
                    this.message = null;
                }
            }
            else {
                this.isBlock = isBlock;
                this.message = null;
            }
        },
        /**
        *描述：调整高度
        */
        setDivHeight: function (resizeTimeNow) {
            //            if (resizeTimeNow != undefined) {
            //                var resizeTime = new Date();
            //                if (resizeTime.getTime() - resizeTimeNow <= 50)
            //                    return;
            //            }
            //当gvHeight不为null的时候，按照指定的值设置高度
            if (typeof (this.options.gvHeight) == "string") {
                if (this.options.gvHeight.indexOf("px") > -1) {//当gvHeight的值为__px的时候
                    var pxHeight = parseFloat(this.options.gvHeight);
                    $(this.GvTable).parent().height(pxHeight);
                    return;
                }
                if (this.options.gvHeight.indexOf("%") > -1) {//当gvHeight的值为__%的时候
                    var percentHeight = parseFloat(this.options.gvHeight) / 100;
                    $(this.GvTable).parent().height(Math.round(document.documentElement.offsetHeight * percentHeight));
                    return;
                }
            }
            //当gvHeight为null的时候，自动调整高度
            var Dv = this.GvTable.parentElement;
            var mendingTop = Dv.offsetTop;
            while (Dv != null && Dv.offsetParent != null && Dv.offsetParent.tagName.toLowerCase != "body") {
                mendingTop += Dv.offsetParent.offsetTop;
                Dv = Dv.offsetParent;
            }
            var divHeight = document.documentElement.offsetHeight - mendingTop - 45;
            if (divHeight > 150) {
                $(this.GvTable).parent().height(divHeight);
            }
            else {
                $(this.GvTable).parent().height("150");
            }
        },
        /**
        *描述：重写表头方法（不完整，暂不使用）
        */
        rewriteHeader: function (header) {
            var ColumnCount = 0;
            var rowCount = 0;
            header.level = 0;
            this.headerRowCount = getRowCount(header);
            var oldHeader = $(this.GvTable).find("tr:eq(0)")
            for (var i = 1; i < this.headerRowCount; i++) {
                oldHeader.after(oldHeader.clone()[0]);
            }
            var arrHeader = [[]];
            function getLeafNode(obj) {
                var flag = false;
                $(obj).each(function () {
                    if (this.hasOwnProperty("header")) {
                        getLeafNode(this.header);
                    }
                    else {
                        arrHeader[0].push(this)
                    }
                })
                return ColumnCount;
            }
            var i = 0
            function toArrByLeafNode() {
            }
            function getRowCount(obj) {
                curLevel = obj.level;
                if (curLevel > rowCount) { rowCount = curLevel; }
                $(obj).each(function () {
                    if (this.hasOwnProperty("header")) {
                        this.header.level = curLevel + 1
                        getRowCount(this.header);
                    }
                })
                return rowCount;
            }
        },
        /**
        *描述：行事件处理
        */
        rowEventHandler: function () {
            var index = this.selectedRowIndex
            var curRowData = getRowData(this, index); //当前行数据的数组
            var flag = arguments[0]
            switch (flag) {
                //删除行处理                                                                                                                                                                                           
                case "delete":
                    //当为$().removeRow(rowIndex,fn)的时候（对指定行执行fn方法后，并根据fn返回值（true、false）执行删除）
                    if (arguments.length == 3) {
                        var index = parseFloat(arguments[1]) || (-1)
                        var removeFunction = arguments[2];
                        if (!removeFunction.call(this.selectRow, curRowData)) return;
                        $(this.GvTable).find("tr:eq(" + index + ")").remove()
                    }
                        //当为$().removeRow(fn)的时候（对当前行执行fn方法后，并根据fn返回值（true、false）执行删除）
                    else if (arguments.length == 2 && typeof (arguments[1]) == "function") {
                        var removeFunction = arguments[1];
                        if (!removeFunction.call(this.selectRow, curRowData)) return;
                        $(this.selectRow).remove();
                    }
                        //当为$().removeRow(rowIndex)的时候（删除指定行）
                    else if (arguments.length == 2) {
                        var index = parseFloat(arguments[1]) || (-1)
                        $(this.GvTable).find("tr:eq(" + index + ")").remove()
                    }
                        //当为$().removeRow()的时候（删除当前行）
                    else {
                        $(this.selectRow).remove();
                    }
                    this.arrTbBody.splice((index - this.headerRowCount), 1);
                    if (index >= this.GvTable.rows.length)
                        index = this.GvTable.rows.length - 1;
                    break;
                case "hidden":
                    break;
                    //修改行处理                                                                                                                                                                                           
                case "update":
                    var updateData = null;
                    //当为$().updateRow(rowIndex,fn)的时候
                    if (arguments.length == 3 && typeof (arguments[2]) == "function") {
                        var index = parseFloat(arguments[1]) || (-1)
                        var updateFunction = arguments[2];
                        updateData = updateFunction.call(this.selectRow, curRowData);
                    }
                        //当为$().updateRow(rowIndex,[])的时候
                    else if (arguments.length == 3 && $.isArray(arguments[2])) {
                        var index = parseFloat(arguments[1]) || (-1);
                        updateData = arguments[2]
                    }
                        //当为$().updateRow(cellIndex,value)的时候
                    else if (arguments.length == 3 && typeof (arguments[1]) == "number") {
                        curRowData[arguments[1]] = arguments[2];
                        updateData = curRowData;
                    }
                        //当为$().updateRow(itemID,value)的时候
                    else if (arguments.length == 3 && typeof (arguments[1]) == "string") {
                        updateData = curRowData;
                        var itemID = arguments[1];
                        var value = arguments[2];
                        setselectedRowValueById(itemID, this.selectRow, value);
                    }
                        //当为$().updateRow(fn)的时候
                    else if (arguments.length == 2 && typeof (arguments[1]) == "function") {
                        var updateFunction = arguments[1];
                        updateData = updateFunction.call(this.selectRow, curRowData);
                    }
                        //当为$().updateRow([])的时候
                    else {
                        updateData = arguments[1]
                    }
                    if (!$.isArray(updateData)) return;
                    if (updateData.length != curRowData.length) return
                    for (var i = 0; i < updateData.length; i++) {
                        var cell = $(this.selectRow).children("td")[i]
                        if ($(cell).children().length == 0)
                            cell.innerHTML = updateData[i];
                        else
                            setValue(cell, updateData[i]);
                        this.arrTbBody[index - this.headerRowCount][i] = new tableCell($(this.selectRow).children("td")[i]);
                    }
                    break
                default:
                    break;

            }
            //修改完成后的初始化操作
            this.$GvBody = $(this.GvTable).find("tr:gt(" + (this.headerRowCount - 1) + ")");
            var initSelectedRow = this.$GvBody[index - this.headerRowCount];
            this.selectRow = initSelectedRow;
            this.curRow = initSelectedRow;
            this.selectedRowIndex = index;
            $(this.prevRow).removeClass(this.options.selectedRowCss);
            $(initSelectedRow).addClass(this.options.selectedRowCss);
            this.prevRow = initSelectedRow;
            $("#" + this.options.txtIndex).val(index);
            removeColor(this);
            if (typeof (this.options.onRowClick) == "function") {
                this.options.onRowClick.call(this.selectRow, curRowData);
            }
            function setValue(obj, value) {
                $(obj).children().each(function () {
                    if (this.clientWidth != 0)
                        $(this).val(value);
                    else
                        setValue(this, value);
                });
            }
        }
    };
    /*调用方法*/

    /**
    *描述：获取当前table表头行数
    *传入参数：obj 当前GridView()对象的实例
    *返回参数：headerRowCount 表头行数
    */
    function getHeaderRow(obj) {
        var tb = obj.GvTable;
        var headerRowCount = 0;
        for (var i = 0; i < tb.rows.length; i++) {
            var isHeaderRow = true;
            for (var j = 0; j < tb.rows[i].cells.length; j++) {
                if (tb.rows[i].cells[j].colSpan > 1 || tb.rows[i].cells[j].rowSpan > 1) {
                    isHeaderRow = false;
                }
            }
            headerRowCount++;
            if (isHeaderRow) {
                obj.headerRowCount = headerRowCount;
                return headerRowCount;
            }
        }
    }
    /**
    *描述：多表头重置样式
    *传入参数：obj 当前GridView()对象的实例
    */
    function setHeaderCss(obj) {
        if (obj.headerRowCount == 1) return;
        var tb = obj.GvTable;
        //将原来表头的图片替换
        $(tb).children("TBODY").children("TR").removeClass("GridViewFixedHeader th");
        $(tb).children("TBODY").children("TR").children("th").addClass("GridViewMultiHeader");
    }
    /**
    *描述：获取table中的数据，存储于arrTb中
    *传入参数：obj 当前GridView()对象的实例
    *返回参数：arrTb 记录table数据
    *          arrTbHead 表头数据
    *          arrTbHead 表体数据 
    */
    function getGvData(obj) {
        var tb = obj.GvTable;
        var arrTb = new Array();
        for (var i = 0; i < tb.rows.length; i++) {
            arrTb[i] = new Array();
            for (var j = 0; j < tb.rows[i].cells.length; j++) {
                if (tb.rows[i].cells[j]) {
                    arrTb[i][j] = new tableCell(tb.rows[i].cells[j]);
                }
            }
        }
        //        obj.arrTb = objectClone(arrTb);
        //分离表头和表体
        obj.arrTbHead = arrTb.slice(0, obj.headerRowCount);
        obj.arrTbBody = arrTb.slice(obj.headerRowCount, arrTb.length);
    }
    /**
    *描述：判断表体是否有合并单元格,并返回未合并单元格的列数
    *传入参数：obj 当前GridView()对象的实例
    *返回参数：unmergeColsCount 记录没有进行单元格合并的列数
    *          isMergeCellsGv 记录是否为复杂表体
    */
    function isMergeCells(obj) {
        var tbBody = obj.arrTbBody;
        obj.unmergeColsCount = tbBody[0].length;
        for (var i = 1; i < tbBody.length; i++) {
            if (obj.unmergeColsCount > tbBody[i].length) {
                obj.unmergeColsCount = tbBody[i].length;
                obj.isMergeCellsGv = true;
            }
        }
    }
    /**
    *描述：动态调整表格宽度
    */
    function resizeColWidth(obj) {
        var currTh;
        var top;
        var isMouseDown = false;
        var $GvTable = $(obj.GvTable);
        var divID = "gvResizeColWidthLine";
        var i = 1;
        while ($("#" + divID + "").length > 0) {
            divID += i;
            i++;
        }
        $("body").bind("selectstart", function () { return !obj.isResize; });
        $("body").append("<div id=\"" + divID + "\" style=\"width:1px;height:200px;border-left:1px solid red; position:absolute;display:none\" ></div> ");
        obj.$GvHeader.children("TH").bind("mousedown", function (event) {
            var th = $(this);
            var pos = th.offset();
            if (event.clientX - pos.left < 4 || (th.width() - (event.clientX - pos.left)) < 4) {
                top = pos.top;
                obj.isResize = true;
                if (event.clientX - pos.left < th.width() / 2) {
                    currTh = th.prev();
                }
                else {
                    currTh = th;
                }
                th.css("cursor", "w-resize");
                isMouseDown = true;
            }
        });
        obj.$GvHeader.children("TH").bind("mousemove", function (event) {
            var th = $(this);
            var pos = th.offset();
            if (event.clientX - pos.left < 4 || (th.width() - (event.clientX - pos.left)) < 4) {
                th.css("cursor", "w-resize");
            }
            else {
                th.css("cursor", "pointer");
            }
        });
        $GvTable.bind("mousemove", function (event) {
            if (isMouseDown) {
                var divHeight = $GvTable.parent().height();
                var tableHeight = $GvTable.height();
                var height = divHeight < tableHeight ? divHeight : tableHeight;
                $("#" + divID).css({
                    "height": height,
                    "top": top,
                    "left": event.clientX,
                    "display": "",
                    "cursor": "w-resize"
                });
                obj.isResize = true;
                $("#" + divID).show();
                $GvTable.css("cursor", "w-resize");

            }
        });
        //IE中onmouseup事件有时候会触发table上的，有时候会触发在拖拽那条线的div上，故都写上mouseup事件
        $("#" + divID).bind("mouseup", function (event) {
            if (obj.isResize) {
                $("#" + divID).hide();
                var index = currTh.nextAll().length;
                var curThWidth = event.clientX - currTh.offset().left;
                var nextThWidth = currTh.next().width() - event.clientX + currTh.next().offset().left;
                currTh.parent().parent().find("tr").each(function () {
                    var $td = $(this).children()
                    var count = $td.length
                    $td.eq(count - index - 1).width(curThWidth);
                    $td.eq(count - index - 1).next().width(nextThWidth);
                });
                obj.isResize = false;
                isMouseDown = false;
                top = undefined;
                currTh = undefined;
                $GvTable.children("TH").css("cursor", "pointer");
                $GvTable.css("cursor", "pointer");
                top = null;
                currTh = null;
            }
        });
        $GvTable.bind("mouseup", function (event) {
            if (obj.isResize) {
                $("#" + divID + "").hide();
                var index = currTh.nextAll().length;
                var curThWidth = event.clientX - currTh.offset().left;
                var nextThWidth = currTh.next().width() - event.clientX + currTh.next().offset().left;
                currTh.parent().parent().find("tr").each(function () {
                    var $td = $(this).children()
                    var count = $td.length
                    $td.eq(count - index - 1).width(curThWidth);
                    $td.eq(count - index - 1).next().width(nextThWidth);
                });
                obj.isResize = false;
                isMouseDown = false;
                top = undefined;
                currTh = undefined;
                $GvTable.children("TH").css("cursor", "pointer");
                $GvTable.css("cursor", "pointer");
                top = null;
                currTh = null;
            }
        });
    }
    /**
    *描述：事件绑定
    *传入参数：obj 当前GridView()对象的实例
    */
    function eventBinding(obj) {
        obj.$GvBody = $(obj.GvTable).children("TBODY").children("tr:gt(" + (obj.headerRowCount - 1) + ")");
        obj.$GvHeader = $(obj.GvTable).children("TBODY").children("tr:lt(" + obj.headerRowCount + ")");
        $(obj.GvTable).bind({
            click: function (event) {
                var tag = getTarget(event);
                switch (tag._tagName) {
                    case "td":
                        if (obj.isBlock) return isShowMessage(obj);
                        var curRow = tag._target.parentElement;
                        obj.onGvRowClick(curRow);
                        break;
                    case "th":
                        if (tag._target.colSpan == 1) {
                            if (obj.isBlock) return isShowMessage(obj);
                            obj.onClickCellsSort(tag._target);
                        }
                        break;
                }
            },
            dblclick: function (event) {
                var tag = getTarget(event);
                if (tag._tagName == "td") {
                    if (obj.isBlock) return isShowMessage(obj);
                    var curRow = tag._target.parentElement;
                    obj.onGvDbRowClick(curRow);
                }
            },
            mouseover: function (event) {
                var tag = getTarget(event);
                if (tag._tagName == "td") {
                    var curRow = tag._target.parentElement;
                    obj.curRow = curRow;
                    if (!$(curRow).hasClass(obj.options.selectedRowCss))
                        $(curRow).addClass(obj.options.mouseOverRowCss);
                    removeColor(obj);
                }

            },
            mouseout: function (event) {
                var tag = getTarget(event);
                if (tag._tagName == "td") {
                    var curRow = tag._target.parentElement;
                    obj.curRow = obj.selectRow;
                    $(curRow).removeClass(obj.options.mouseOverRowCss);
                    removeColor(obj);
                }
            }
        })
    }
    /**
    *描述：定义单元格对象，将单元格内的HTML代码、单元格显示的值、单元格的colSpan和rowSpan存储到对象属性中
    *传入参数：obj 当前单元格，如tb.rows[2].cells[3]
    */
    function tableCell(obj) {
        var gvShowValue = "";
        getValue(obj);
        //属性
        this.innerHTML = obj.innerHTML;
        this.colSpan = obj.colSpan;
        this.rowSpan = obj.rowSpan;
        this.showValue = gvShowValue;
        //.replace(/[ \r\n]/g, "")//去掉空格、回车、换行
        //        var td = $(obj);
        //        this.showValue = td.children().length == 0 ? obj.innerHTML : td.find(":visible:last").val();
        //递归遍历获取子控件第一个不是隐藏控件的value，如果没有控件则返回innerHTML

        function getValue(obj) {

            var mObj = obj;
            var childNode = $(mObj).contents()
            var childNodeCount = childNode.length;
            if (childNodeCount != 0) {
                for (var i = 0; i < childNodeCount; i++) {
                    if (childNode[i].nodeName == "#text") {
                        gvShowValue += childNode[i].nodeValue;
                    }
                    else if ((childNode[i].offsetWidth > 0 || childNode[i].offsetHeight > 0) && childNode[i].style.display != "none") {
                        getValue(childNode[i]);
                    }
                }
            }
            else {
                if (mObj.value)
                    gvShowValue += mObj.value;
                else
                    gvShowValue += mObj.nodeValue;
            }
        }
    }
    /**
    *描述：将gridView保存成导出Excel的字符串
    */
    function gvConvertToString(obj) {
        var vData = "<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=GB2312\"/>";
        vData += "<table cellspacing=\"0\" border=\"1px\" style=\"background-color: White; border-collapse: collapse;\">";
        for (var i = 0; i < obj.arrTb.length; i++) {
            vData += "<tr>";
            for (var j = 0; j < obj.arrTb[i].length; j++) {
                vData += "<td style=\"vnd.ms-excel.numberformat:@;\" colspan=\"" + obj.arrTb[i][j].colSpan + "\" rowspan=" + obj.arrTb[i][j].rowSpan + ">" + obj.arrTb[i][j].showValue + "</td>";
            }
            vData += "</tr>";
        }
        vData += "</table>";
        try {
            var $txtExcel = $("#" + this.options.txtExcel + "");
            if ($txtExcel.length > 0) {
                $txtExcel[0].value = vData;
            }
        }
        catch (e) { }
    }
    /**
    *描述：页面加载完成后选中对选中行和高度初始化
    */
    function init(obj) {
        $(obj.GvTable).parent().addClass("GridViewDiv");
        //        obj.setDivHeight();

        var $txtIndex = $("#" + obj.options.txtIndex + "");
        if ($txtIndex.length > 0) {
            var selectedIndex = $txtIndex[0].value;
            if (selectedIndex == "" || selectedIndex >= obj.GvTable.rows.length) {
                selectedIndex = obj.headerRowCount;
                $txtIndex[0].value = selectedIndex;
            }
        }
        else {
            var selectedIndex = obj.headerRowCount;
        }
        var initSelectedRow = obj.$GvBody[selectedIndex - obj.headerRowCount];
        obj.selectRow = initSelectedRow;
        obj.curRow = initSelectedRow;
        obj.selectedRowIndex = selectedIndex;
        $(initSelectedRow).addClass(obj.options.selectedRowCss);
        obj.prevRow = initSelectedRow;
        //处理合并行，去掉不规整的部分的变色
        removeColor(obj);
        if (typeof (obj.options.onRowClick) == "function") {
            var rowData = getRowData(obj, selectedIndex)
            obj.options.onRowClick.call(obj.selectRow, rowData);
        }
    }
    /**
    *描述：自动调整gridview高度
    */
    function resizeGv(obj) {
        $(window).resize(function () {
            var resizeTimeNow = new Date();
            obj.setDivHeight(resizeTimeNow.getTime());
        });
    }
    /**
    *描述：固定元素（不支持ie7，暂不用）
    */
    function fixedItem(obj) {
        var $Div = $(obj.GvTable).parent();
        if (obj.options.fixedCols != null) {
            var cols = obj.options.fixedCols.split(",")
            var $_tr = $(obj.GvTable).find("tr")
            $Div.scroll(function () {
                for (var i = 0; i < cols.length; i++) {
                    $_tr.each(function () {
                        _td = $(this).children()[i]
                        $(_td).css({ position: "relative", left: $Div.scrollLeft() + "px" });
                    });
                }
            });
        }
        var $th = obj.$GvHeader.children("th")
        $Div.scroll(function () {
            $th.each(function () {
                $(this).css({ position: "relative", top: $Div.scrollTop() + "px" });
            });
        });
    }
    /**
    *描述：根据id获取值
    *传入参数：ID  控件id;
    */
    var value;
    function getselectedRowValueById(itemID, obj) {
        var mItemID = itemID;
        var mObj = obj;
        var childrenCount = mObj.children.length;
        for (var i = 0; i < childrenCount; i++) {
            if (mObj.children[i].id.indexOf(mItemID) >= 0) {
                value = mObj.children[i].value;
                break;
            }
            else {
                if (childrenCount != 0) {
                    getselectedRowValueById(mItemID, mObj.children[i]);
                }
            }
        }
        return value;
    }
    /**
    *描述：根据id设置值
    *传入参数：ID  控件id;
    */
    function setselectedRowValueById(itemID, obj, value) {
        var mItemID = itemID;
        var mObj = obj;
        var childrenCount = mObj.children.length;
        for (var i = 0; i < childrenCount; i++) {
            if (mObj.children[i].id.indexOf(mItemID) >= 0) {
                mObj.children[i].value = value;
                break;
            }
            else {
                if (childrenCount != 0) {
                    setselectedRowValueById(mItemID, mObj.children[i], value);
                }
            }
        }
    }
    /**
    *描述：获取当前行的数据
    */
    function getRowData(obj, selectedIndex) {
        var arrData = new Array();
        var arrRow = obj.arrTbBody[selectedIndex - obj.headerRowCount];
        $(arrRow).each(function () {
            arrData.push(this.showValue);
        })
        return arrData;
    }
    /**
    *描述：处理合并行，去掉不规整的部分的变色
    */
    function removeColor(obj) {
        if (obj.isMergeCellsGv) {
            if (obj.curRow.cells.length != obj.unmergeColsCount) {
                for (var i = 0; i < (obj.curRow.cells.length - obj.unmergeColsCount) ; i++) {
                    obj.curRow.children[i].style.backgroundColor = obj.pubRowColor;
                }
            }
        }
    }
    /**
    *描述：对象和数组深度克隆
    *传入参数：obj 需要克隆的对象
    *返回参数：newObj 复制出来的对象
    */
    function objectClone(obj) {
        if (typeof (obj) != 'object') return obj;
        if (obj == null) return obj;
        var newObj = obj instanceof Array ? [] : {};
        for (var i in obj) {
            newObj[i] = (typeof obj[i] === 'object') ? objectClone(obj[i]) : obj[i];
        }
        return newObj;
    }
    /**
    *描述：控件锁定后提示消息方法
    */
    function isShowMessage(obj) {
        if (obj.isBlock && obj.message != null)
            alert(obj.message);
    }
    /**
    *描述：获得复杂表结构的cellindex
    */
    function getCellIndex(th) {
    }
    /**
    *
    */
    function getTarget(event) {
        var strTagName = ["td", "th", "tr", "tbody", "table"];
        var _target = event.target;
        var _tagName = _target.tagName.toLowerCase();
        while ($.inArray(_tagName, strTagName) == -1) {
            _target = _target.parentElement;
            _tagName = _target.tagName.toLowerCase();
        }
        var tag = {}
        tag._target = _target;
        tag._tagName = _tagName
        return tag
    }
})(jQuery);