import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface NirStage {
    id: number;
    code: string;
    name: string;
}

@Component({
    template: "Превед",
    components: {
        // тут можно добавить локльные компоненты
      },
})
export default class NirComponent extends Vue {
    nirStages: NirStage[] = [
        { id: 0, code: "1", name: "Stage 1" }
    ];
}
