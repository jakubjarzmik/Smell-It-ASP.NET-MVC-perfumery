window.onload = function () {
    var chart = new CanvasJS.Chart('chartContainer', {
        animationEnabled: true,
        theme: 'light2',
        title: {
            text: 'Daily Visitors',
        },
        data: [
            {
                type: 'line',
                indexLabelFontSize: 16,
                dataPoints: [
                    { y: 450 },
                    { y: 414 },
                    {
                        y: 520,
                        indexLabel: '\u2191 highest',
                        markerColor: 'red',
                        markerType: 'triangle',
                    },
                    { y: 460 },
                    { y: 450 },
                    { y: 500 },
                    { y: 480 },
                    { y: 480 },
                    {
                        y: 410,
                        indexLabel: '\u2193 lowest',
                        markerColor: 'DarkSlateGrey',
                        markerType: 'cross',
                    },
                    { y: 500 },
                    { y: 480 },
                    { y: 510 },
                ],
            },
        ],
    });
    setTimeout(function () {
        chart.render();
    }, 1000);
};

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems, {
        coverTrigger: false
    });
});
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.sidenav');
    var instances = M.Sidenav.init(elems, {

    });
});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.modal');
    var instances = M.Modal.init(elems, {

    });
});

document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems, {

    });
});
