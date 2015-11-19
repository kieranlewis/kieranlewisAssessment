var CourseModule = (function () {

    return {
        getCourse: function (callback) {

            var xhttp = new XMLHttpRequest();
            
            //This gets triggered when the state of the xhttp object changes
            xhttp.onreadystatechange = function () {
                // 4 - repsonse is ready, 200 success code
                if (xhttp.readyState == 4 && xhttp.status == 200) {
                    loadedCourse();
                }
            }
            
            // Build up our request and send it - true for async
            xhttp.open("GET", "http://msauniversity.azurewebsites.net/api/Students", true);
            xhttp.setRequestHeader("Content-type", "application/json");
            xhttp.send(null);
            
            // Parse and send the studentlist data back to index.js
            function loadedCourse() {
                var courseList = JSON.parse(xhttp.responseText);
                callback(courseList);
                return courseList;
            }
        }
    }
}