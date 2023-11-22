
@Obsolete()
export class Collection<T> extends Array<T> {
  updateFunc: Function = () => {
    //this.toggleChange = !this.toggleChange;
    //this.cd.detectChanges();
  };

  constructor() {
    super();
  }

  override push(...items: T[]): number {
    var ret = super.push(...items);
    this.updateFunc();

    return ret;
  }

  subscribe(updateFunc: Function): void {
    this.updateFunc = updateFunc;
  }

  clear(...newItems: T[]) {
    while (this.length > 0) {
      super.pop();
    }

    if (newItems) {
      super.push(...newItems);
    }

    this.updateFunc();
  }

  override unshift(...items: T[]): number {
    var ret = super.unshift(...items);
    this.updateFunc();

    return ret;
  }
}

function Obsolete(): (target: typeof Collection) => void | typeof Collection {
    throw new Error("Function not implemented.");
}
