$(function() {
    var $inputExpression = $(Constants.ExpressionSelector);
    
    $inputExpression.autocomplete({
      source: autocompleteWordsServer.getData,
      focus: function (event, ui) {
        $inputExpression.val(ui.item.word);
            return false;
      },
      select: function (event, ui) {
        $inputExpression.val(ui.item.word);
            return false;
      },
      minLength: 1
    })
    .data(Constants.UiAutocomplete)._renderItem = function( ul, item ) {
      return $("<li>")
        .append( "<div>" + item.word + "<span class='frequency'>" + item.frequency + "</span> </div>" )
        .appendTo( ul );
    };
});