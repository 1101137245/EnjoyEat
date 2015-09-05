




$(function () {

    /*
     * Tabs
     */
    $('.work-section').each(function () {

        var $container = $(this),                            // a
            $navItems = $container.find('.tabs-nav li'),     // b
            $highlight = $container.find('.tabs-highlight'); // c
        // 將Tab的各元素轉為jQuuery物件
        // a 包含Tab和Panel的整體container
        // b Tab列表
        // c 選択中Tab的Highlight

        // 執行jQuery UI Tabs
        $container.tabs({

            // 設定為不顯示時的動畫
            hide: { duration: 250 },

            // 設定為顯示時的動畫
            show: { duration: 125 },

            // 讀取時與選擇時Highlight位置的調整
            create: moveHighlight,
            activate: moveHighlight
        });

        // 調整Highlight位置的函數
        function moveHighlight (event, ui) {
            var $newTab = ui.newTab || ui.tab,  // 新選擇Tab的jQuery物件
                left = $newTab.position().left; // 新選擇Tab的left

            // Highlight位置的動畫
            $highlight.animate({ left: left }, 500, 'easeOutExpo');

        }
    });

});


//餐廳照片輪播
    $(function(){
        // 取得 .respic 及其子孫元素 li
        var $block = $('.respic'), 
            $li = $block.find('li');
        
        // 從 li 中取出超連結及大圖片來產生新的內容
        var _html = '';
        $li.each(function(){
            var $this = $(this), 
                $a = $this.find('a'),  
                $thumb = $a.find('img')
        });

        // 把產生的新內容加到 $block 中
        // 並先隱藏除了第一個以外的元素
        var $link = $block.append(_html).children('a').css({
            position: 'absolute', 
            opacity: 0
        }).eq(0).animate({
            opacity: 1, 
            zIndex: 10
        }).end();

        // 當 $li 點擊時
        $li.click(function(){
            // 顯示相對索引的 $link 並把其它的設為透明
            $link.eq($(this).index()).stop().animate({
                opacity: 1, 
                zIndex: 10
            }).siblings('a').stop().animate({
                opacity: 0, 
                zIndex: 0
            });

            return false;
        });

        $block.find('a').focus(function(){
            this.blur();
        });
    });



//個餐點顯示
    $(window).load(function(){
        // 預設滑鼠移入或移出時的邊框顏色及移動的速度
        var _hoverInBorderColor = 'rgba(178, 34, 34,0.5);', 
            hoverOutBorderColor = '#E5E5E5', 
            _animateSpeed = 500;

        // 當滑鼠移入或移出 .meals 時
        $('.meals').hover(function(){
            // 先取得 .link 及其圖片
            // 並計算出要移動的距離(寬度)
            var $link = $(this).find('.link'), 
                _width = $link.width(), 
                $img = $link.find('img'), 
                _imgWidth = $img.width(), 
                _leftPosition = _width - _imgWidth;
            
            // 當滑鼠移入時顯示其它邊框顏色
            $link.stop().animate({
                borderBottomColor: _hoverInBorderColor,
                borderLeftColor: _hoverInBorderColor,
                borderRightColor: _hoverInBorderColor,
                borderTopColor: _hoverInBorderColor
            }, _animateSpeed);
            
            // 當滑鼠移入時移動圖片
            $img.stop().animate({
                left: _leftPosition
            }, _animateSpeed);
        }, function(){
            var $link = $(this).find('.link'), 
                $img = $link.find('img');
            
            // 當滑鼠移出時顯示原本的邊框顏色
            $link.stop().animate({
                borderBottomColor: hoverOutBorderColor,
                borderLeftColor: hoverOutBorderColor,
                borderRightColor: hoverOutBorderColor,
                borderTopColor: hoverOutBorderColor
            }, _animateSpeed);
            
            // 當滑鼠移出時移動圖片回原位
            $img.stop().animate({
                left: 0
            }, _animateSpeed);
        });
    });




// 餐點切換
         $(function () {
        $('.book').each(function () {
          $(this).booklet({pageNumbers: false,manual:false,overlays:true,hovers:true});        
        });
      });