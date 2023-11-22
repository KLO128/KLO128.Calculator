export interface HomeViewState {
  result: string | undefined;
  historyResults: any[];
  expression: string | undefined;
  useSeparators: boolean;
  resultAsInteger: boolean;
  loading: boolean;
  [key: string]: any
}
