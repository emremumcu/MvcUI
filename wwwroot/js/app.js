
// Document Ready ...

$(document).ready(function() {
    // ...
});

jQuery(function() {
    // ...
});

$(function() {
    // ...
});

// .. Document Ready


// Application Theme:



// Application Theme:


//// Loading
window.addEventListener('load', function ()
{
    // Prepare loading div:
    var divLoading = document.createElement('div');
    divLoading.id = 'divLoading';
    divLoading.className = 'hide';

    var divCenter = document.createElement('div');
    divCenter.id = 'materialLoadingCentered'

    var divContent = document.createElement('div');
    divContent.id = 'materialLoadingContent';
    divContent.innerHTML = '<i class="fas fa-2x fa-spinner fa-spin text-light"></i>';

    divCenter.appendChild(divContent);
    divLoading.appendChild(divCenter);

    document.body.appendChild(divLoading);  
})

function loading(state)
{
    if (state) document.getElementById('divLoading').className = 'show';
    else document.getElementById('divLoading').className = 'hide';
}
//// Loading