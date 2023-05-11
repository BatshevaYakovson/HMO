
import * as moment from 'moment';

export default function formatDate(datestring) {
    return moment(datestring).format("D/MM/YYYY");
}