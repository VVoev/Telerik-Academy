(function($) {
    $.fn.zoom = function() {
        this.on('mouseover', function() {
            var $this = $(this);
            var oldWidth = parseInt($this.css('width'));
            var oldHeight = parseInt($this.css('height'));
            $this.css('width', (oldWidth * 3) + 'px');
            $this.css('height', (oldHeight * 3) + 'px');
        });

        this.on('mouseout', function() {
            var $this = $(this);
            var oldWidth = parseInt($this.css('width'));
            var oldHeight = parseInt($this.css('height'));
            $this.css('width', (oldWidth / 3) + 'px');
            $this.css('height', (oldHeight / 3) + 'px');
        });

        // For chaining
        return this;
    };
}(jQuery));