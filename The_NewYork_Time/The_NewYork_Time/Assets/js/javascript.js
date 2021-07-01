

function tab(){
    var $ = document.querySelector.bind(document);
    var $$ = document.querySelectorAll.bind(document);
    var tabs = $$('.tab-item');
    var panes = $$('.tab-pane');      
    let tabActive =  $('.tab-item.active');

    var line = $('.tabs .line');
    line.style.left = tabActive.offsetLeft + 'px';
    line.style.width = tabActive.offsetWidth + 'px';
    tabs.forEach((tab, index) => {
        var pane = panes[index];
        tab.onclick = function(){
                
            $('.tab-item.active').classList.remove('active');
            this.classList.add('active');
            $('.tab-pane.active').classList.remove('active');
            pane.classList.add('active');
            line.style.left = this.offsetLeft + 'px';
            line.style.width = this.offsetWidth + 'px';

        }
    })
}



