import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import NirStage from '../nirStage';

@Component({
    components: {
        'add-software-dev-labor-modal': require('./addSoftwareDevLaborGroupModal.vue.html'),
      },
})
export default class NirStageCardComponent extends Vue {
    @Prop() nirStage!: NirStage;
    showAddSoftwareDevLaborGroupModal: boolean = false;

}