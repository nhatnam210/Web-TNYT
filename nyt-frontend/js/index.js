// ---- TIME CONSTANTS
const daysOfWeek = [
    'Sunday', 'Monday', 'Tuesday', 'Wednesday',
    'Thursday', 'Friday', 'Saturday'
]; const months = [
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
]; const oponionCol = [
    'Today\'s Opinion', 'Columnists', 'Editorials', 'Guest Essays',
    'Letters', 'Sunday Review', 'Video: Opinion'
]; const artsCol = [
    'Today\'s Arts', 'Arts & Design', 'Books',
    'Best Sellers Book List', 'Dance', 'Movies', 'Music',
    'Pop Culture', 'Television', 'Theater', 'Video: Arts'
]; const livingCol = [
    'Automotive', 'Games', 'Education', 'Food',
    'Health', 'Jobs', 'Love', 'Magazine', 'Parenting',
    'Real Estate', 'Style', 'T Magazine', 'Travel'
]; const moreCol = [
    'Reader Center', 'Wirecutter', 'Cooking', 'Live Events',
    'The Learning Network', 'Tools & Services', 'Podcasts',
    'Multimedia', 'Photography', 'Video', 'TimesMachine',
    'NYT Store', 'Manage My Account', 'NYTLicensing'
]; const subscribeCol = [
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

// NEWS DRAWER CATEGORIES
const drawerGroupFirst = [
    "Home Page", "World", "Business", "Politics", "U.S.", "Sports",
    "Health", "N.Y.", "Opinion", "Tech", "Science"
]; const drawerGroupSecond = [
    "Arts", "Books", "Style", "Food", "Travel", "Magazine",
    "T Magazine", "Real Estate", "Obituaries", "Video", "The Upshot"
]; const drawerGroupSub = {
    "world": [
        "Africa", "Australia", "Americas", "Asia Pacific",
        "Canada", "Europe", "Middle East"
    ], "business": [
        "DealBook", "Economy", "Energy", "Markets", "Media",
        "Entrepreneurship", "Your Money", "Automotive"
    ], "politics": [
        "President Biden", "Supreme Court", "Congress"
    ], "us": [
        "Education", "California Today", "Race/Related"
    ], "sports": [
        "Olympics", "MLB", "NBA", "NFL", "NHL", "NCAA Basketball",
        "NCAA Football", "Golf", "Soccer", "Tennis"
    ], "health": [
        "Money & Policy", "Health Guide"
    ], "opinion": [
        "Columnists", "Editorials", "Guest Essays", "Letters", "Sunday Review",
    ], "tech": [
        "Personal Tech", "Cybersecurity", "Social Media"
    ], "science": [
        "Personal Tech", "Cybersecurity", "Social Media"
    ], "arts": [
        "Art & Design", "Dance", "Movies", "Music", "Pop Culture",
        "Television", "Theater", "What to Watch", "Awards Season"
    ], "books": [
        "Best Sellers", "By the Book", "The Book Review",
        "Book Review Podcast", "Globetrotting"
    ], "style": [
        "Fashion", "Men's Style", "On the Runway", "Love", "Self-Care"
    ], "food": [
        "NYT Cooking", "Restaurant Search", "Wine, Beer & Cocktails", "What to Cook"
    ], "tmagazine": [
        "Design & Interiors", "Food", "Travel", "Fashion & Beauty",
        "Entertainment", "Art", "Video", "The T List"
    ], "realestate": [
        "On the Market", "Mortgage Calculator", "Living In",
        "The High End", "What You Get"
    ], "video": [
        "U.S. & Politics", "International", "N.Y.", "Op-Docs", "Opinion",
        "Times Documentaries", "Business", "Tech", "Culture", "Style", "T Magazine",
        "Health", "Food", "Travel", "Sports", "Real Estate", "Science"
    ], "more": [
        "Trending", "Reader Center", "Parenting", "Wirecutter",
        "Live Events", "Games", "Newsletters", "The Learning Network",
        "Multimedia", "Photography", "Podcasts", "NYT Store", "NYT Wine Club",
        "School of NYT", "TimesMachine", "Subscribe", "Manage Account",
        "Today's Paper", "Tools & Services", "Jobs", "Corrections"
    ]
}

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

function parseDrawer() {
    // First group
    drawerGroupFirst.forEach(row => {
        let id = row.toLowerCase().replaceAll('.', '').replaceAll(' ','')
        $('#group-first').append(
            '<li id="group-' + id + '" class="list-group-item btn-group border-0 p-0 mt-1">' +
            '<a href="#" class="btn col-link small fw-bold p-0 m-0" data-bs-toggle="dropdown" aria-expanded="false">' + row + '</a></li>'
        )

        if (Object.keys(drawerGroupSub).includes(id)) {
            // Add dropdown indicator if there is a sub-menu for this menu
            $('#group-' + id + ' a').addClass('dropdown-toggle')

            // Add dropdown popup
            $('#group-' + id).append('<ul class="dropdown-menu dropdown-menu-end" style="z-index: 5000 !important;">')
            $('#group-' + id + ' ul').append(
                '<li class="list-group-item border-0 p-0 mt-1">' +
                '<small class="text-uppercase text-muted">' + row + '</small></li>'
            )
            drawerGroupSub[id].forEach(row => $('#group-' + id + ' ul').append(
                '<li class="list-group-item border-0 p-0 mt-1">' +
                '<a href="#" class="btn col-link small fw-bold p-0 m-0 dropdown-item">' + row + '</a></li>'
            ));
            $('#group-' + id).append('</ul>')
        }
    });
    $('#group-first').append('<hr/>');

    // Second group
    drawerGroupSecond.forEach(row => {
        let id = row.toLowerCase().replace('.', '').replace(' ','')
        $('#group-second').append(
            '<li id="group-' + id + '" class="list-group-item btn-group border-0 p-0 mt-1">' +
            '<a href="#" class="btn col-link small fw-bold p-0 m-0" data-bs-toggle="dropdown" aria-expanded="false">' + row + '</a></li>'
        )

        if (Object.keys(drawerGroupSub).includes(id)) {
            // Add dropdown indicator if there is a sub-menu for this menu
            $('#group-' + id + ' a').addClass('dropdown-toggle')

            // Add dropdown popup
            $('#group-' + id).append('<ul class="dropdown-menu dropdown-menu-end" style="z-index: 5000 !important;">')
            $('#group-' + id + ' ul').append(
                '<li class="list-group-item border-0 p-0 mt-1">' +
                '<small class="text-uppercase text-muted">' + row + '</small></li>'
            )
            drawerGroupSub[id].forEach(row => $('#group-' + id + ' ul').append(
                '<li class="list-group-item border-0 p-0 mt-1">' +
                '<a href="#" class="btn col-link small fw-bold p-0 m-0 dropdown-item">' + row + '</a></li>'
            ));
            $('#group-' + id).append('</ul>')
        }
    });
    $('#group-second').append('<hr/>');

    // Third group
    $('#group-third').append(
        '<li id="group-more" class="list-group-item btn-group dropend border-0 p-0 mt-1">' +
        '<a href="#" class="btn col-link small fw-bold p-0 m-0 dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">More</a></li>'
    );
    // Add dropdown indicator
    $('#group-more a').addClass('dropdown-toggle')
    // Add dropdown popup
    $('#group-more').append('<ul class="dropdown-menu dropdown-menu-end" style="z-index: 5000 !important;">')
    $('#group-more ul').append(
        '<li class="list-group-item border-0 p-0 mt-1">' +
        '<small class="text-uppercase text-muted">More</small></li>'
    )
    drawerGroupSub['more'].forEach(row => $('#group-more ul').append(
        '<li class="list-group-item border-0 p-0 mt-1">' +
        '<a href="#" class="btn col-link small fw-bold p-0 m-0 dropdown-item">' + row + '</a></li>'
    ));
    $('#group-more').append('</ul>')
}

$(document).ready(
    function() {
        parseToday()
        parseCategory()
        parseFooterColumns()
        parseDrawer()
    }
)