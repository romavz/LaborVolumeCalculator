import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import NirStage from './nirStage';

@Component({
    components: {
        'nir-stage-card': require('./components/nirStageCard.vue.html'),
      },
    
})
export default class NirComponent extends Vue {
    nirStages: NirStage[] = [];

    mounted() {
        fetch('/api/Nir/NirStages')
            .then(response => response.json())
            .then(data => {
                this.nirStages = data;
            });
    }
}