import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import NirStage from '../nirStage';

@Component({
    components: {
        
      },
})
export default class addSoftwareDevLaborGroupModalComponent extends Vue {
    @Prop() nirStage!: NirStage;
    softwareDevLaborGroups: ISoftwareDevLaborGroup[] = [];
    solutionInnovationRates: ISolutionInnovationRate[] = [];
    standardModulesUsingRates: IStandardModulesUsingRate[] = [];
    testsScales: ITestsScale[] = [];
    testCoverageLevels: ITestCoverageLevel[] = [];
    componentsMicroarchitectures: IComponentsMicroArchitecture[] = [];
    infrastructureComplexityRates: IInfrasctructureComplexityRate[] = [];
    componentsMakroArchitectures: IComponentsMakroArchitecture[] = [];
    componentsInteractionArchitectures: IComponentsInteractionArchitecture[] = [];
    testsDevelopmnetRate: ITestsDevelopmentRate[] = [];

    close() {
        this.$emit('close-add-software-dev-labor-modal', this.nirStage.id);
    }

    mounted() {
        this.loadSoftwareDevLaborGroups();
        this.loadSolutionInnovationRates();
        this.loadStandardModulesUsingRates();
    }

    loadSoftwareDevLaborGroups() {
        fetch("/api/NirSoftwareDevLaborGroup/GetAllButThis")
            .then(response => response.json() as Promise<ISoftwareDevLaborGroup[]>)
            .then(data => {
                this.softwareDevLaborGroups = data;
            });
    }

    // solution-innovation-rate slot data
    loadSolutionInnovationRates() {
        
    }

    // standard-module-using-rate slot data
    loadStandardModulesUsingRates() {

    }

    // test-development-rate slot data
    loadTestsScales() {

    }

    loadTestsCoverageLevels() {

    }

    loadComponentsMicroArchitectures() {
        
    }

    // infrastructure-complexity-rate slot data
    loadInfrastructureComplexityRates() {

    }

    // architecture-complexity-rate slot data
    loadComponentsInteractionArchitectures() {

    }

    loadComponentsMakroArchitectures() {

    }

    getTestDevelopmentrate(microArchId: number, testsScaleId: number, testsCoverLevelId: number) {
        // var rate = ((TestsDevelopmentRate[])Model.ViewData["TestsDevelopmentRates"])
        //     .Where(m => m.ComponentsMicroArchitectureID == microArch.ID && m.TestsCoverageLevelID == coverLevel.ID && m.TestsScaleID == scale.ID)
        //     .FirstOrDefault();
        return 1.2;
    }

}

interface IDictionaryItemBase {
    id: number,
    code: string,
    name: string    
}

interface ISoftwareDevLaborGroup extends IDictionaryItemBase { }
interface ISolutionInnovationRate extends IDictionaryItemBase { } 
interface IStandardModulesUsingRate extends IDictionaryItemBase { }
interface ITestsScale extends IDictionaryItemBase { }
interface ITestCoverageLevel extends IDictionaryItemBase { }
interface IComponentsMicroArchitecture extends IDictionaryItemBase { }
interface IInfrasctructureComplexityRate extends IDictionaryItemBase { }
interface IComponentsInteractionArchitecture extends IDictionaryItemBase { }
interface IComponentsMakroArchitecture extends IDictionaryItemBase { }

interface ITestsDevelopmentRate {
    componentsMicroArchitectureID: number,
    testsCoverageLevelID: number,
    testsScaleID: number,
    id: number,
    value: number
}