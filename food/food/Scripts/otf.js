$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        }

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        })

        // prevent browser from doing default action
        //ev.preventDefault();
        return false;
    }

    var submitAutocompleteForm = function(event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    }

    var createAutocomplete = function () {
        var $input = $(this);

        console.log("create autocomplete:", $input);
        console.log("source:", $input.attr("data-otf-autocomplete"));

        
        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        }

        $input.autocomplete(options);
        // extended jquery added autocomplete method
        $(".main-content").on("click", ".pagedList a", getPage);
    }

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });
        return false;
    }

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);

    $(".main-content").on("click", ".pagedList a", getPage);

});