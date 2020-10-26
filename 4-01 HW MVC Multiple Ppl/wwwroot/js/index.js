$(() => {

    let i = 1;

        $("#addrow").on('click', () => {
            $("#rows").append
                (    `<div class="row well">
                        <div class="col-md-4">
                            <input type="text" name="ppl[${i}].First" class="form-control" placeholder="First name" />
                        </div>
                        <div class="col-md-4">
                            <input type="text" name="ppl[${i}].Last"} class="form-control" placeholder="Last name" />
                        </div>
                        <div class="col-md-4">
                            <input type="text" name="ppl[${i}].Age"} class="form-control" placeholder="Age" />
                        </div>
                    </div>` );
            i++;
        });
    

    });