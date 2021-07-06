// ---- TIME CONSTANTS
const daysOfWeek = [
    'Sunday', 'Monday', 'Tuesday', 'Wednesday',
    'Thursday', 'Friday', 'Saturday'
]
const months = [
        'January', 'February', 'March', 'April', 'May', 'June', 'July',
        'August', 'September', 'October', 'November', 'December'
    ]
    // ---- NEWS HEADER CATEGORIES
const categories = [
        'World', 'U.S.', 'Politics', 'N.Y.', 'Business',
        'Opinion', 'Tech', 'Science', 'Health', 'Sports',
        'Arts', 'Books', 'Style', 'Food', 'Travel',
        'Magazine', 'T Magazine', 'Real Estate', 'Video'
    ]
    // ---- NEWS FOOTER CATEGORIES
const newsCol = [
    'Home Page', 'World', 'Coronavirus', 'U.S.', 'Politics',
    'New York', 'Business', 'Tech', 'Science', 'Sports',
    'Obituaries', 'Today\'s Paper', 'Corrections', 'Trending'
]
const oponionCol = [
    'Today\'s Opinion', 'Columnists', 'Editorials', 'Guest Essays',
    'Letters', 'Sunday Review', 'Video: Opinion'
]
const artsCol = [
    'Today\'s Arts', 'Arts & Design', 'Books',
    'Best Sellers Book List', 'Dance', 'Movies', 'Music',
    'Pop Culture', 'Television', 'Theater', 'Video: Arts'
]
const livingCol = [
    'Automotive', 'Games', 'Education', 'Food',
    'Health', 'Jobs', 'Love', 'Magazine', 'Parenting',
    'Real Estate', 'Style', 'T Magazine', 'Travel'
]
const moreCol = [
    'Reader Center', 'Wirecutter', 'Cooking', 'Live Events',
    'The Learning Network', 'Tools & Services', 'Podcasts',
    'Multimedia', 'Photography', 'Video', 'TimesMachine',
    'NYT Store', 'Manage My Account', 'NYTLicensing'
]
const subscribeCol = [
    '<b><ion-icon name="newspaper-outline"></ion-icon> Home Delivery</b>',
    '<b><ion-icon name="card-outline"></ion-icon> Digital Subscriptions</b>',
    '<b><ion-icon name="grid-outline"></ion-icon> Games</b>',
    '<b><ion-icon name="restaurant-outline"></ion-icon> Cooking</b>',
    '<small>Email Newsletters</small>',
    '<small>Corporate Subscriptions</small>',
    '<small>Education Rate</small>',
    '<hr class="p-0 my-1"/>',
    '<small>Mobile Applications</small>',
    '<small>Replica Edition</small>',
    '<small>International</small>',
    '<small>Vietnam</small>'
]

function parseToday() {
    let today = new Date()
    let dow = daysOfWeek[today.getDay()]
    let dd = String(today.getDate()).padStart(2, '0')
    let mmmm = months[today.getMonth()]
    let yyyy = today.getFullYear()

    today = dow + ', ' + mmmm + ' ' + dd + ', ' + yyyy
    $('#info-today').html('<b>' + today + '</b>')
}

function parseCategory() {
    categories.forEach(category => $('#header-navbar').append(
        '<li class="nav-item"><a class="nav-link" href="#">' + category + '</a></li>'
    ));
    $(".nav-item").css("margin", "-5px");
    $(".nav-item").css("font-size", "12px");
}

function parseFooterColumns() {
    newsCol.forEach(row => $('#news-col>ul').append(
        '<li class="list-group-item border-0 p-0 my-1"><a class="col-link" href="#">' + row + '</a></li>'
    ));
    oponionCol.forEach(row => $('#opinion-col>ul').append(
        '<li class="list-group-item border-0 p-0 my-1"><a class="col-link" href="#">' + row + '</a></li>'
    ));
    artsCol.forEach(row => $('#arts-col>ul').append(
        '<li class="list-group-item border-0 p-0 my-1"><a class="col-link" href="#">' + row + '</a></li>'
    ));
    livingCol.forEach(row => $('#living-col>ul').append(
        '<li class="list-group-item border-0 p-0 my-1"><a class="col-link" href="#">' + row + '</a></li>'
    ));
    moreCol.forEach(row => $('#more-col>ul').append(
        '<li class="list-group-item border-0 p-0 my-1"><a class="col-link" href="#">' + row + '</a></li>'
    ));
    subscribeCol.forEach(row => $('#subscribe-col>ul').append(
        '<li class="list-group-item border-0 p-0 my-1"><a class="col-link" href="#">' + row + '</a></li>'
    ));
}

$(document).ready(
    function() {
        parseToday()
        parseCategory()
        parseFooterColumns()
    }
)