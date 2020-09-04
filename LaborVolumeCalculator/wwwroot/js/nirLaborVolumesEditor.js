class Labor {
    id = 0;
    code = "";
    name = "";
    minVolume = 0.0;
    maxVolume = 0.0;

    constructor(id = 0, code = "", name = "", minVolume = 0.0, maxVolume = 0.0) {
        this.id = id;
        this.code = code;
        this.name = name;
        this.minVolume = minVolume;
        this.maxVolume = maxVolume;
    }
}

class NirLaborEditHelper {
    constructor() {
        this.index = 0;
    }

    createLabor(row) {
        return new Labor(
            parseInt(row.attr('data-laborID')),
            row.find("[name='labor-Code']").first().text().trim(),
            row.find("[name='labor-Name']").first().text().trim(),
            parseFloat(row.find("[name='labor-MinVolume']").first().text().trim()),
            parseFloat(row.find("[name='labor-MaxVolume']").first().text().trim()),
        );
    }

    forEachCheckedRow(selectList, func) {
        let checkedItems = selectList.find("input:checked");
        selectList.has(checkedItems).each(func);
    }

    addLaborsToNirStageTable(laborsArray, nirStageID) {
        let self = this;
        let nirInnovationRate = parseFloat($('#nirInnovationRateValue').text().trim());
        let table = $('#LaborVolumesForNirStage-' + nirStageID);
        laborsArray.forEach(function (labor, index, array) {
            let row = self.createNirStageLaborsTableRecord(nirStageID, labor, labor.minVolume, labor.minVolume * nirInnovationRate);
            table.append(row);
        });
    };
    
    createNirStageLaborsTableRecord(nirStageID, labor, volume, totalVolume) {
        this.index += 1;
        let tableRow = $(
            `<tr data-laborID="${labor.id}">
                <td  hidden="hidden">
                    <input type="hidden" name="RegistredLabors.Index" value="${this.index}" />
                    <input type="hidden" name="RegistredLabors[${this.index}].ID" value="0" />
                    <input type="hidden" name="RegistredLabors[${this.index}].NiokrID" value="@Model.Nir.ID"/>
                    <input type="hidden" name="RegistredLabors[${this.index}].NiokrStageID" value="${nirStageID}"/>
                    <input type="hidden" name="RegistredLabors[${this.index}].LaborID" value="${labor.id}"/>
                    <input type="hidden" name="RegistredLabors[${this.index}].TotalVolume" value="${totalVolume}"/>
                </td>
                <th scope="row" name="laborCode">${labor.code}</th>
                <td name="laborName">${labor.name}</td>
                <td name="laborMinVolume">${labor.minVolume}</td>
                <td name="laborMaxVolume">${labor.maxVolume}</td>
                <td>
                    <input name="RegistredLabors[${this.index}].Volume" class="form-control volumeEditBox" value="${volume}" data-nirStageID="${nirStageID}" />
                </td>
                <td name="TotalVolume">${totalVolume}</td>
                <td>
                    <button type="button"
                            class="btn btn-link btn-sm d-inline align-middle removeLaborButton"
                            data-laborID="${labor.id}"
                            data-nirStageID="${nirStageID}">Удалить</button>
                </td>
            </tr>`);

        $(tableRow).on('click', '.removeLaborButton', this.onRemoveLabor_buttonHandler.bind(this));
        $(tableRow).on('keydown change', '.volumeEditBox', this.onVolumeChange_handler.bind(this));

        return tableRow;
    }



    recalcNirStageTotalLaborsVolume(nirStageID) {
        let nirStageTotalVolume = 0;
        let volumes = $(`#LaborVolumesForNirStage-${nirStageID} td[name$="TotalVolume"]`);

        volumes.each(function (index, element) {
            nirStageTotalVolume += parseFloat($(element).text().trim());
        });

        $(`#nirStageLaborsVolumeTotal-${nirStageID}`).text(round(nirStageTotalVolume, 4));
        this.recalcNirTotalLaborsVolume();
    }

    recalcNirTotalLaborsVolume() {
        let totalVolume = 0;
        $("[id^='nirStageLaborsVolumeTotal']").each(function (index, element) {
            totalVolume += parseFloat($(element).text());
        });

        $('#nir-labor-volumes-total').text(round(totalVolume, 4));
    }

    recalcLaborTotalVolume(editBox) {
        let nirInnovationRate = parseFloat($('#nirInnovationRateValue').text().trim());
        let newVolume = parseFloat(editBox.val());
        let totalVolume = round(newVolume * nirInnovationRate, 4);
        let row = editBox.closest('tr')
        row.find("input[name$='TotalVolume']").val(totalVolume);
        row.find("td[name$='TotalVolume']").text(totalVolume);

        let nirStageID = editBox.attr('data-nirStageID');
        this.recalcNirStageTotalLaborsVolume(nirStageID);
    }

    recalcTotals() {
        let self = this;
        $("[name='nirStageCard']").each(function (index, nirCardElement) {
            let nirStageID = $(nirCardElement).attr("data-nirStageID");
            self.recalcNirStageTotalLaborsVolume(nirStageID);
        });
    }


    closeLaborSelectionModal(nirStageID) {
        $('#laborsSelectionModal-' + nirStageID).modal("hide");
    }

    onRemoveLabor_buttonHandler(event) {
        let deleteButton = $(event.target);
        let nirStageID = deleteButton.attr('data-nirStageID');
        let laborID = deleteButton.attr('data-laborID');
        $(`#LaborVolumesForNirStage-${nirStageID} tr`).has(deleteButton).remove();
        $(`#laborSelectionList-${nirStageID} .row[data-laborID="${laborID}"]`).attr('hidden', false);

        this.recalcNirStageTotalLaborsVolume(nirStageID);
    }

    onVolumeChange_handler(event) {
        if (event.key == 'Enter' || event.type == 'change') {
            event.preventDefault();
            let editBox = $(event.target);
            this.recalcLaborTotalVolume(editBox);
        }
    }

    loadNirLaborVolumes() {
        let self = this;

        $('.LaborVolumesForNirStage').each(function (index, element) {
            let nirStageSection = $(element);
            let nirID = $('#Nir_ID').val();
            let nirStageID = nirStageSection.attr('data-nirStageID');

            $.get(`/api/laborVolumeReg?niokrID=${nirID}&niokrStageID=${nirStageID}`)
                .done(function (laborVolumeRegs) {
                    $.each(laborVolumeRegs, function (i, regRecord) {
                        let row = self.createNirStageLaborsTableRecord(nirStageID, regRecord.labor, regRecord.volume, regRecord.totalVolume)
                        nirStageSection.append(row);
                    });

                self.recalcTotals();
            });
        });

    }
}

function round(value, decimals) {
    return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
}