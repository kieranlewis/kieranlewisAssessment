document.addEventListener("DOMContentLoaded", function () {
    var controller = document.body.getAttribute("data-controller");
    if (controller === "courses") {
        loadSCoursesTable(controller);
    }
});

function loadCoursesTable(controller) {
    var coursesTable = document.getElementById("tblcoursecontent");
    CourseModule.getCourse(function (courseList) {
        setupCourseTable(courseList);
    });
}