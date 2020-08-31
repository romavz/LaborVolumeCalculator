import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface NirStage {
    id: number;
    name: string;
}

@Component({
    components: {
        // тут можно добавить локльные компоненты
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
