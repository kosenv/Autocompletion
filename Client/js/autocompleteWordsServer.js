var autocompleteWordsServer = (function (constants,$) {
    function getData(request, response) {
            $.ajax({
                url: constants.Urls.ServerUrl+constants.Urls.SearchWordsPart + request.term,
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                success: function(data){
                  response(data);
                },
                error: function (xhr, status, errorThrown) {
                    alert(xhr.responseText);
                }
            });
    }


    function refresh() {
        $.ajax({
            url: constants.Urls.ServerUrl+constants.Urls.UpdateServerDatePart,
            type: 'POST',
            cache: false,
            success: function (data, status) {
                if(status == 'success')
                    alert('Данные обновлены.');
                else
                    alert('Ошибка при обновлении.');
            },
            error: function (jqXHR, status, errorThrown) {
                alert(jqXHR.responseText);
            }
        });
    }

    return {
      getData: getData,
      refreshData : refresh
    }
  }(Constants,jQuery));