$.fn.tabs = function () {
    let $tabController = $(this);
    $tabController.addClass('tabs-container');
    $tabController.find('.tab-item-content').hide();
    
    $tabController.on('click','.tab-item-title',function () {
        let $clickedElement = $(this);
        $tabController.find('.tab-item-content').hide();
        clearClass($tabController);
        $clickedElement.next().show();
        $clickedElement.parent().addClass('current');
    })
    
    function clearClass($tabController) {
        $tabController.find('.tab-item').removeClass('current');
    }
};